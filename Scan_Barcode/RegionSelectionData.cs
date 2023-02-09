using System;
using System.Drawing;

namespace Scan_Barcode
{
    class RegionSelectionData
    {
        private Point pStartViewer, pStopViewer, pStartImage, pStopImage;
        private bool isCameraNo2;
        string sStartsWith;

        public Point LocationText
        {
            get { return pStartViewer; }
        }

        public bool IsCamera2
        {
            get { return isCameraNo2; }
        }

        public string StartsWith
        {
            set { sStartsWith = value; }
            get { return sStartsWith; }
        }

        public RegionSelectionData(bool isCameraNo2, Point pStartViewer, Point pStopViewer, Point pStartImage, Point pStopImage, string sStartsWith)
        {
            this.isCameraNo2 = isCameraNo2;
            this.pStartViewer = pStartViewer;
            this.pStopViewer = pStopViewer;
            this.pStartImage = pStartImage;
            this.pStopImage = pStopImage;
            this.sStartsWith = sStartsWith;
        }

        public RegionSelectionData(string StringValue)
        {
            try
            {
                char[] Spearator = { ',', ':', ';' };
                string[] ValueList = StringValue.Split(Spearator, StringSplitOptions.RemoveEmptyEntries);
                if (ValueList[0] == "CAM2") isCameraNo2 = true;
                pStartViewer = new Point(int.Parse(ValueList[1]), int.Parse(ValueList[2]));
                pStopViewer = new Point(int.Parse(ValueList[3]), int.Parse(ValueList[4]));
                pStartImage = new Point(int.Parse(ValueList[5]), int.Parse(ValueList[6]));
                pStopImage = new Point(int.Parse(ValueList[7]), int.Parse(ValueList[8]));
                sStartsWith = ValueList[9];
            }
            catch (Exception) { }
        }

        public void UpdateValue(bool isCameraNo2, Point pStartViewer, Point pStopViewer, Point pStartImage, Point pStopImage, string sStartsWith)
        {
            this.isCameraNo2 = isCameraNo2;
            this.pStartViewer = pStartViewer;
            this.pStopViewer = pStopViewer;
            this.pStartImage = pStartImage;
            this.pStopImage = pStopImage;
            this.sStartsWith = sStartsWith;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Math.Min(pStartViewer.X, pStopViewer.X), Math.Min(pStartViewer.Y, pStopViewer.Y), Math.Abs(pStartViewer.X - pStopViewer.X), Math.Abs(pStartViewer.Y - pStopViewer.Y));
        }

        public Rectangle GetImageRectangle()
        {
            return new Rectangle(Math.Min(pStartImage.X, pStopImage.X), Math.Min(pStartImage.Y, pStopImage.Y), Math.Abs(pStartImage.X - pStopImage.X), Math.Abs(pStartImage.Y - pStopImage.Y));
        }
        
        public string GetDataRegionSelection()
        {
            return "CAM" + (isCameraNo2 ? "2" : "1") + $";{pStartViewer.X},{pStartViewer.Y}:{pStopViewer.X},{pStopViewer.Y};{pStartImage.X},{pStartImage.Y}:{pStopImage.X},{pStopImage.Y};{sStartsWith}";
        }

        public override string ToString()
        {
            return "[CAM" + (isCameraNo2 ? "2" : "1") + $"]\t[{pStartViewer.X},{pStartViewer.Y}:{pStopViewer.X},{pStopViewer.Y}]\t[{sStartsWith}]";
        }
    }
}
