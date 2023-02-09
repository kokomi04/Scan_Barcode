using System;
using System.Drawing;

namespace Scan_Barcode_Dual
{
    public class RegionSelectionData
    {      
            private Point pStartViewer, pStopViewer, pStartImage, pStopImage;

            public Point LocationText
            {
                get { return pStartViewer; }
            }

            public RegionSelectionData(Point pStartViewer, Point pStopViewer, Point pStartImage, Point pStopImage)
            {
                this.pStartViewer = pStartViewer;
                this.pStopViewer = pStopViewer;
                this.pStartImage = pStartImage;
                this.pStopImage = pStopImage;
            }

            public RegionSelectionData(string StringValue)
            {
                char[] Spearator = { ',', ':', ';' };
                string[] ValueList = StringValue.Split(Spearator, StringSplitOptions.RemoveEmptyEntries);
                pStartViewer = new Point(int.Parse(ValueList[0]), int.Parse(ValueList[1]));
                pStopViewer = new Point(int.Parse(ValueList[2]), int.Parse(ValueList[3]));
                pStartImage = new Point(int.Parse(ValueList[4]), int.Parse(ValueList[5]));
                pStopImage = new Point(int.Parse(ValueList[6]), int.Parse(ValueList[7]));
            }

            public void UpdateValue(Point pStartViewer, Point pStopViewer, Point pStartImage, Point pStopImage)
            {
                this.pStartViewer = pStartViewer;
                this.pStopViewer = pStopViewer;
                this.pStartImage = pStartImage;
                this.pStopImage = pStopImage;
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
                return $"{pStartViewer.X},{pStartViewer.Y}:{pStopViewer.X},{pStopViewer.Y};{pStartImage.X},{pStartImage.Y}:{pStopImage.X},{pStopImage.Y}";
            }

            public override string ToString()
            {
                return $"[{pStartViewer.X},{pStartViewer.Y}:{pStopViewer.X},{pStopViewer.Y}]";
            }
        }
}
