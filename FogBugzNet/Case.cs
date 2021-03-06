#region

using System;

#endregion

namespace FogBugzNet
{
    public class Case
    {
        public string Area;
        public string AssignedTo;
        public string Category;
        public TimeSpan Elapsed;
        public TimeSpan Estimate;
        public int ID;
        public string Name;
        public int ParentCaseID;

        public MileStone ParentMileStone = new MileStone();
        public Project ParentProject;

        public string ShortDescription
        {
            get { return ID + ": " + Name; }
        }

        public string ElapsedTime_h_m // returns elapsed time in h:m format: 20:04
        {
            get
            {
                return String.Format("{0}:{1}",
                                     Elapsed.TotalHours.ToString("###"),
                                     Elapsed.Minutes.ToString("0#"));
            }
        }

        public string LongDescription
        {
            get { return String.Format("{0}:{1}:{2}:{3} - {4}", ParentProject.Name, Area, AssignedTo, ID, Name); }
        }
    }
}