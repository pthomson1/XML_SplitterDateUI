using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.Threading;
using System.Web;
using XML_SplitterDateUI.Properties;

namespace XML_SplitterDateUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        private List<DateTime> DateList = new List<DateTime>();
        public List<DateTime> GetList()
        {
            return DateList;
        }

            private void RunButton_Click(object sender, EventArgs e)
            {
            var beginningDate = BeginningDateTimePicker.Value;
            var endingDate = EndingDateTimePicker.Value;

            var confirmResult = MessageBox.Show($"Are these dates correct? ({beginningDate.ToString("MM/dd/yyyy")} to {endingDate.ToString("MM/dd/yyyy")})\n\nWarning: Process may take time.", "Confirm", MessageBoxButtons.YesNo);
            var DaysDifference = Math.Abs(beginningDate.Day - endingDate.Day);
            // creates list that stores each day between the start and end date 
            for (int day = 0; day <= DaysDifference; day++)
            {
                DateList.Add(beginningDate);
                beginningDate = beginningDate.AddDays(1);
            }

            if (confirmResult == DialogResult.Yes)
            {
                Split();
                DateList.Clear(); // resets list to prevent duplicates if run button is pressed more than once
            }
        }
       
        public void Split()
        {
            string saveLocation = Settings.Default["saveLocation"].ToString();
            string xmlLocation = Settings.Default["xmlLocation"].ToString();
            DateTime today = DateTime.Today;
            Stopwatch stopWatch = new Stopwatch();

            int index = 0;
            string previousFileDate = "";

            //string saveLocation = "\\\\Automate2101\\d\\Applications\\MDMIntervalDataParser\\DailyMDMDataOutput";
            //string xmlLocation = "\\\\Automate2101\\d\\Applications\\AMRDailyReadProcessing\\FullIntDataSource";


            string filePath = "";

            stopWatch.Start();

            foreach (var path in Directory.GetFiles(@xmlLocation))
            {
                String fileDate = GetFileDate(System.IO.Path.GetFileName(path).Substring(20));

                
                foreach (var day in this.GetList())
                {
                   
                    if (fileDate.Equals(day.ToString("MM/dd/yyyy")))    // if the file's date matches the date in list proceed
                    {
                        previousFileDate = day.ToString("MM/dd/yyyy");
                        filePath = xmlLocation + "\\" + System.IO.Path.GetFileName(path);    // instantiate the filePath to equal the xmlLocation and the file being examined

                        XDocument newDoc = XDocument.Load(filePath);

                        XmlReader xmlReader = newDoc.CreateReader();


                        // For AMRDEF Element
                        string amrdefPurpose = "";
                        string amrdefVersion = "";
                        string amrdefCreationTime = "";

                        // For ScheduleExecution Element
                        string scheduleExecutionIrn = "";
                        string scheduleExecutionStarted = "";
                        string scheduleExecutionFinished = "";
                        string scheduleExecutionInitiator = "";


                        /* gathers the values for each attribute and stores it for use in the final output */
                        while (xmlReader.Read())
                        {
                            if (xmlReader.Name.Equals("AMRDEF")) // If "AMRDEF" Element is found instantiate the following attribute values.
                            {
                                amrdefPurpose = xmlReader.GetAttribute("Purpose");
                                amrdefVersion = xmlReader.GetAttribute("version");
                                amrdefCreationTime = xmlReader.GetAttribute("CreationTime");
                            }

                            if (xmlReader.Name.Equals("ScheduleExecution")) // If "ScheduleExecution" Element is found instantiate the following attribute values.
                            {
                                scheduleExecutionIrn = xmlReader.GetAttribute("Irn");
                                scheduleExecutionStarted = xmlReader.GetAttribute("started");
                                scheduleExecutionFinished = xmlReader.GetAttribute("finished");
                                scheduleExecutionInitiator = xmlReader.GetAttribute("Initiator");
                                break;
                            }
                        }



                        var query = newDoc.Root.Descendants("ScheduleExecution").DescendantNodes(); // Get all nodes found within, but not including, the "SceduleExecution" Element
                        XElement header = new XElement("ScheduleExecution", new XAttribute("Irn", scheduleExecutionIrn),
                            new XAttribute("started", scheduleExecutionStarted),
                            new XAttribute("finished", scheduleExecutionFinished),
                            new XAttribute("Initiator", scheduleExecutionInitiator), query);  // Take the Header ("ScheduleExecution") of the current XML File being examined

                        newDoc.Descendants("ScheduleExecution").Remove(); // Remove the Header ("ScheduleExecution") from the newDoc object

                        int elementsPerFile = GetNumberOfElementsPerNewFile(newDoc);

                        // adds {elementsPerFile} elements to a new file that then saves to a folder
                        foreach (var batch in newDoc.Root.Elements().InSetsOf(elementsPerFile))
                        {
                            var finalDoc = new XDocument(
                                 new XElement("AMRDEF", new XAttribute("Purpose", amrdefPurpose), new XAttribute("version", amrdefVersion), new XAttribute("CreationTime", amrdefCreationTime), header, batch));
                            finalDoc.Save($"{saveLocation}\\meterDataFile_{day.ToString("MM/dd/yyyy").Replace("/", "_")}_{++index}.xml");
                            System.GC.Collect(); // attempt to reduce unnecessary memory usage
                        }
                    }
                    else if (fileDate.Equals(previousFileDate) == false)
                    {
                        index = 0;
                    }

                }
            }

            stopWatch.Stop();
            MessageBox.Show($"Process Completed.\n\nTime Elapsed: {stopWatch.Elapsed.ToString("mm\\:ss")}");

            /****************************************************************************/
            /*The Following modifies the file's date in the format MM/dd/yyy*/
            static string GetFileDate(string fileDate)
            {
                String date = fileDate;
                date = date.Replace('_', '/');
                date = date.Substring(0, 10);
                return date;
            }

            /***************************************************************************/
            /* Below Counts the Original XML file's Elements which then determines, and returns, how many
             * Elements each new file showed display */
            static int GetNumberOfElementsPerNewFile(XDocument newDoc)
            {
                double scalarVariableCount = newDoc.Root.Elements().Count();
                double numberOfElementsPerFile = Math.Ceiling(scalarVariableCount / 24);
                int elementAmount = Convert.ToInt32(numberOfElementsPerFile);

                return elementAmount;
            }

        }


        // Selects and stores source files folder location 
        private void selectSourceFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = Properties.Settings.Default["LastSelectedXMLFolder"].ToString();
            folder.Description = ("Please select the folder in which the source files are stored.");
            if (folder.ShowDialog() == DialogResult.OK)
            {
                Settings.Default["xmlLocation"] = folder.SelectedPath;
                Properties.Settings.Default["LastSelectedXMLFolder"] = folder.SelectedPath.ToString();
                Properties.Settings.Default.Save();
            }
        }

        // Selects and stores saved files folder location 
        private void selectSaveLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = Properties.Settings.Default["LastSelectedSaveFolder"].ToString();
            folder.Description = ("Please select a folder to save the files to.");
            if (folder.ShowDialog() == DialogResult.OK)
            {
                Settings.Default["saveLocation"] = folder.SelectedPath;
                Properties.Settings.Default["LastSelectedSaveFolder"] = folder.SelectedPath.ToString();
                Properties.Settings.Default.Save();
            }
        }
    }

    /*********************************************************************************************/
    /**** This class assists in determing how many elements should be included in one "batch" ****/
    public static class IEnumerableExtensions
    {
        public static IEnumerable<List<T>> InSetsOf<T>(this IEnumerable<T> source, int max)
        {
            List<T> toReturn = new List<T>(max);
            foreach (var item in source)
            {
                toReturn.Add(item);
                if (toReturn.Count == max)
                {
                    yield return toReturn;
                    toReturn = new List<T>(max);
                }
            }
            if (toReturn.Any())
            {
                yield return toReturn;
            }
        }
    }
}

