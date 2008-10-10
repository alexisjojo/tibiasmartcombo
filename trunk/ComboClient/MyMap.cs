﻿/*
 * Copyed from tibiaapi and minor changed check tibiaapi you are free to use it in a program u ask money for
 */


using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Tibia;
using Tibia.Objects;
using ComboClient;

namespace Tibia
{
    public class MyMap
    {
        // Public Constants
        public const int MapFileDimension = 256;
        public const int FloorMax = 15;
        public const int FloorMin = 0;
        public const string MaskOT = "0??0??";
        public const string MaskReal = "1??1??";

        // Public Delegates
        public delegate void MapFloorToImageCallback(int percentageComplete);

        // Public Settings
        public bool DrawCrosshair = true;
        public bool DrawCoors = false;
        public bool OTMaps = false;
        public string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tibia\\Automap\\";

        // Private Variables
        public PictureBox pictureBox;
        private Graphics g;
        private Rectangle mapBoundary;
        private int currentZ = 7;
        private Bitmap[] floorImages = new Bitmap[FloorMax + 1];
        private Point startingPos;
        private Point imagePos = new Point(0, 0);
        private Size imageSize;
        private Image mapImage;
        private double zoomFactor = 1;
        FormMapCopy formMap;

        public MyMap(PictureBox p, FormMapCopy formMap)
        {
            this.formMap = formMap;
            pictureBox = p;
            g = p.CreateGraphics();
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.Resize += pictureBox_Resize;
        }

        ~MyMap()
        {
            pictureBox.MouseDown -= pictureBox_MouseDown;
            pictureBox.MouseMove -= pictureBox_MouseMove;
            pictureBox.Paint -= pictureBox_Paint;
            pictureBox.Resize -= pictureBox_Resize;
        }

        public void close()
        {
            mapImage.Dispose();
            for (int i = 0; i < floorImages.Length; i++)
            {
                if (floorImages[i] != null)
                    floorImages[i].Dispose();
            }
        }

        #region pictureBox Handlers
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    startingPos.X = e.X;
                    startingPos.Y = e.Y;
                    break;
                case MouseButtons.Middle:
                    break;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Size tempsizeP = pictureBox.Size;
                Size tempsize = floorImages[currentZ].Size;
                //System.Console.WriteLine("testtt1111" + imagePos.X + "," + imagePos.Y); 
                if (imagePos.X + (e.X - startingPos.X) < 0 && imagePos.X + (e.X - startingPos.X) > ((-tempsize.Width * zoomFactor) + tempsizeP.Width))
                    imagePos.X += e.X - startingPos.X;
                if (imagePos.Y + (e.Y - startingPos.Y) < 0 && imagePos.Y + (e.Y - startingPos.Y) > ((-tempsize.Height * zoomFactor) + tempsizeP.Height))
                    imagePos.Y += e.Y - startingPos.Y;
                startingPos.X = e.X;
                startingPos.Y = e.Y;
                RedrawMap();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            RedrawMap();
        }

        private void pictureBox_Resize(object sender, EventArgs e)
        {
            g = pictureBox.CreateGraphics();
            LoadMap();
            RedrawMap(true);
            imageSize.Height = (int)(imageSize.Height * 1);
            imageSize.Width = (int)(imageSize.Width * 1);

            Size tempsizeP = pictureBox.Size;
            Size tempsize = floorImages[currentZ].Size;
            if (imagePos.X > 0)
                imagePos.X = 0;
            if (imagePos.Y > 0)
                imagePos.Y = 0;
            if (imagePos.X < ((-tempsize.Width * zoomFactor) + tempsizeP.Width))
                imagePos.X = (int)((-tempsize.Width * zoomFactor) + tempsizeP.Width);
            if (imagePos.Y < ((-tempsize.Height * zoomFactor) + tempsizeP.Height))
                imagePos.Y = (int)((-tempsize.Height * zoomFactor) + tempsizeP.Height);
            RedrawMap();
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Get the boundary coordinates of an array of map files
        /// </summary>
        /// <param name="mapFiles"></param>
        /// <returns></returns>
        private static Rectangle GetBoundary(FileInfo[] mapFiles)
        {
            int left = 0;
            int right = 0;
            int top = 0;
            int bottom = 0;
            bool first = true;
            foreach (FileInfo mapFile in mapFiles)
            {
                Location l = MapFileNameToLocation(mapFile.Name);
                if (first)
                {
                    left = right = l.X;
                    top = bottom = l.Y;
                    first = false;
                }
                else
                {
                    if (l.X < left)
                        left = l.X;
                    else if (l.X > right)
                        right = l.X;

                    if (l.Y < top)
                        top = l.Y;
                    else if (l.Y > bottom)
                        bottom = l.Y;
                }
            }
            return new Rectangle(left, top, right - left + MapFileDimension, bottom - top + MapFileDimension);
        }

        /// <summary>
        /// Get a map file name from coordinates
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        private static string GetMapFileName(string directory, uint x, uint y, uint z)
        {
            return directory +
                (x / MapFileDimension).ToString("000") +
                (y / MapFileDimension).ToString("000") +
                z.ToString("00") + ".map";
        }

        /// <summary>
        /// Convert a map file name to a location
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static Location MapFileNameToLocation(string fileName)
        {
            Location l = new Location(0, 0, 0);
            if (fileName.Length == 12 || fileName.Length == 8)
            {
                l.X = Int32.Parse(fileName.Substring(0, 3)) * MapFileDimension;
                l.Y = Int32.Parse(fileName.Substring(3, 3)) * MapFileDimension;
                l.Z = Int32.Parse(fileName.Substring(6, 2));
            }
            return l;
        }

        /// <summary>
        /// Read a map file into an image
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Image MapFileToImage(string path)
        {
            // All map files are 256 x 256
            Bitmap bitmap = new Bitmap(MapFileDimension, MapFileDimension);

            // Make sure the file actually exists
            if (File.Exists(path))
            {
                // Open the file in a BufferedStream
                using (BufferedStream bs = new BufferedStream(new FileStream(path, FileMode.Open)))
                {
                    // Each map file contains this many pixels
                    byte[] array = new byte[65536];

                    // Read all of them at once (much faster than byte by byte) into an array
                    bs.Read(array, 0, 65536);

                    // Loop through the array
                    int index = 0;
                    for (int x = 0; x < MapFileDimension; x++)
                    {
                        for (int y = 0; y < MapFileDimension; y++)
                        {
                            byte b = array[index];

                            // Set the pixel on the bitmap, converting the byte a color
                            bitmap.SetPixel(x, y, ByteToColor(b));
                            index++;
                        }
                    }
                }
            }

            return bitmap;
        }

        /// <summary>
        /// Convert a map file byte to a color
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Color ByteToColor(byte b)
        {
            switch (b)
            {
                case 0x0C: // Foliage, dark green
                    return Color.FromArgb(0, 0x66, 0);
                case 0x18: // Grass, green
                    return Color.FromArgb(0, 0xcc, 0);
                case 0x1e: // Swamp, bright green
                    return Color.FromArgb(0, 0xFF, 0);
                case 0x28: // Water, blue
                    return Color.FromArgb(0x33, 0, 0xcc);
                case 0x56: // Stone wall, dark grey
                    return Color.FromArgb(0x66, 0x66, 0x66);
                case 0x72: // Not sure, maroon
                    return Color.FromArgb(0x99, 0x33, 0);
                case 0x79: // Dirt, brown
                    return Color.FromArgb(0x99, 0x66, 0x33);
                case 0x81: // Paths, tile floors, other floors
                    return Color.FromArgb(0x99, 0x99, 0x99);
                case 0xB3: // Ice, light blue
                    return Color.FromArgb(0xcc, 0xff, 0xff);
                case 0xBA: // Walls, red
                    return Color.FromArgb(0xff, 0x33, 0);
                case 0xC0: // Lava, orange
                    return Color.FromArgb(0xff, 0x66, 0);
                case 0xCF: // Sand, tan
                    return Color.FromArgb(0xff, 0xcc, 0x99);
                case 0xD2: // Ladder, yellow
                    return Color.FromArgb(0xff, 0xff, 0);
                case 0: // Nothing, black
                    return Color.Black;
                default: // Unknown, white
                    //this.Text = "" + b;
                    return Color.White;
            }
        }
        #endregion

        /// <summary>
        /// Load the map into the picturebox at the currentZ level.
        /// Uses two level caching: the generated bitmap is saved as
        /// a png file in the map directory, and the Bitmap object
        /// is saved in memory.
        /// </summary>
        public void LoadMap()
        {
            Bitmap image;

            // Check if the image is already in memory
            if (floorImages[currentZ] != null)
            {
                image = floorImages[currentZ];
            }
            else
            {
                string dir = directory;

                // Open the directory
                DirectoryInfo di = new DirectoryInfo(dir);

                // Get all the map files
                FileInfo[] mapFiles = di.GetFiles(
                    (OTMaps ? MaskOT : MaskReal) +
                    currentZ.ToString("00") +
                    ".map");

                // Find the boundary
                Rectangle r = GetBoundary(mapFiles);
                mapBoundary = r;

                string imageFileName = dir +
                    (r.Left / MapFileDimension).ToString("000") +
                    (r.Top / MapFileDimension).ToString("000") +
                    currentZ.ToString("00") + ".png";

                // Check if we have an image file previously generated
                if (File.Exists(imageFileName))
                {
                    image = (Bitmap)Bitmap.FromFile(imageFileName);
                }
                else
                {
                    image = MapFloorToImage(dir, currentZ, delegate(int percentage)
                    {
                        DrawPercentBar(percentage);
                    });

                    // Save the image to speed up processing next time
                    image.Save(imageFileName, ImageFormat.Png);
                }
                floorImages[currentZ] = image;
            }

            // Draw the bitmap on the picture box
            if (imageSize.Width == 0)
                imageSize = image.Size;
            mapImage = image;
            RedrawMap();
        }

        /// <summary>
        /// Get an image of the entire map on the specified floor
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="floor"></param>
        /// <returns></returns>
        public Bitmap MapFloorToImage(string dir, int floor)
        {
            return MapFloorToImage(dir, floor, null);
        }

        /// <summary>
        /// Get an image of the entire map on the specified floor
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="floor"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public Bitmap MapFloorToImage(string dir, int floor, MapFloorToImageCallback callback)
        {
            // Open the directory
            DirectoryInfo di = new DirectoryInfo(dir);

            // Get all the map files
            FileInfo[] mapFiles = di.GetFiles((OTMaps ? MaskOT : MaskReal) + floor.ToString("00") + ".map");

            // Find the boundary
            Rectangle r = GetBoundary(mapFiles);

            // Create a new bitmap big enough to hold all the map
            Bitmap b = new Bitmap(r.Width, r.Height);

            // Get the graphics object to draw on the image
            Graphics g = Graphics.FromImage(b);

            // Set the background to be black
            g.Clear(Color.Black);

            // Keep track of how far along we are
            int counter = 0;
            int total = mapFiles.Length;

            // Loop through the map files and draw them onto the bitmap
            foreach (FileInfo mapFile in mapFiles)
            {
                Location l = MapFileNameToLocation(mapFile.Name);
                if (l.Z == currentZ)
                    g.DrawImage(MapFileToImage(dir + mapFile.Name), l.X - r.Left, l.Y - r.Top);
                counter++;
                if (callback != null)
                    callback((int)(counter * 100.0 / total));
            }

            return b;
        }

        /// <summary>
        /// Move down a level
        /// </summary>
        public void LevelUp()
        {
            if (currentZ > 0)
            {
                currentZ--;
                LoadMap();
            }
        }

        /// <summary>
        /// Move up a level
        /// </summary>
        public void LevelDown()
        {
            if (currentZ < 13)
            {
                currentZ++;
                LoadMap();
            }
        }

        /// <summary>
        /// Set the level of the map
        /// </summary>
        /// <param name="z"></param>
        public void SetLevel(int z)
        {
            if (z != currentZ)
            {
                currentZ = z;
                LoadMap();
            }
        }

        /// <summary>
        /// Set the zoom factor for the map
        /// </summary>
        /// <param name="factor"></param>
        public void Zoom(double factor)
        {
            g.Clear(Color.Black);
            Location center = GetMapCenter();

            zoomFactor *= factor;
            if (zoomFactor < 0.25)
            {
                zoomFactor = 0.25;
                factor = 1;
            }
            if (zoomFactor > 32)
            {
                zoomFactor = 32;
                factor = 1;
            }
            System.Console.WriteLine("Zoomfactor" + zoomFactor);

            imageSize.Height = (int)(imageSize.Height * factor);
            imageSize.Width = (int)(imageSize.Width * factor);

            /*
            Size tempsizeP = pictureBox.Size;
            Size tempsize = floorImages[currentZ].Size;

            if (imagePos.X > 0)
                imagePos.X = 0;
            if (imagePos.X < ((-tempsize.Width * zoomFactor) + tempsizeP.Width))
                imagePos.X = (int)((-tempsize.Width * zoomFactor) + tempsizeP.Width);
            if (imagePos.Y > 0)
                imagePos.Y = 0;
            else if (imagePos.Y < ((-tempsize.Height * zoomFactor) + tempsizeP.Height))
                imagePos.Y = (int)((-tempsize.Height * zoomFactor) + tempsizeP.Height);*/
            SetMapCenter(center);
            //RedrawMap();
        }

        /// <summary>
        /// Redraw the map (no background redraw)
        // </summary>
        public void RedrawMap()
        {
            RedrawMap(false);
            formMap.setMarkers();
        }

        /// <summary>
        /// Redraw the map
        /// </summary>
        /// <param name="clear">if true clears the background first (produces a flicker)</param>
        private void RedrawMap(bool clear)
        {
            if (mapImage == null) return;
            if (clear)
                g.Clear(Color.Black);
            g.DrawImage(mapImage, new Rectangle(imagePos, imageSize));
            if (DrawCrosshair)
                DrawCrosshairs();
            if (DrawCoors)
                DrawCoordinates();
        }

        /// <summary>
        /// Convert Tibia coordinates to a point on the map
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Point MapCoorsToPoint(int x, int y)
        {
            return MapCoorsToPoint(new Location(x, y, currentZ));
        }

        /// <summary>
        /// Convert a Tibia Location to a point on the map
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public Point MapCoorsToPoint(Location l)
        {
            int x = l.X;
            int y = l.Y;
            int newX = (int)((x - 31744) * zoomFactor) + imagePos.X;
            int newY = (int)((y - 30976) * zoomFactor) + imagePos.Y;

            return new Point(newX, newY);
        }

        /// <summary>
        /// Convert a point on the map to a Tibia location
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Location PointToMapCoors(Point p)
        {
            int newX = (int)((p.X - imagePos.X) / zoomFactor + 31744);
            int newY = (int)((p.Y - imagePos.Y) / zoomFactor + 30976);

            return new Location(newX, newY, currentZ);
        }

        /// <summary>
        /// Get the point at the center of the picturebox
        /// </summary>
        /// <returns></returns>
        public Point GetMapCenterPoint()
        {
            int x = pictureBox.Width / 2;
            int y = pictureBox.Height / 2;

            return new Point(x, y);
        }

        /// <summary>
        /// Set the center of the map to a Tibia Location
        /// </summary>
        /// <param name="l"></param>
        public void SetMapCenter(Location l)
        {
            Point center = GetMapCenterPoint();

            //int newX = (int)((l.X - mapBoundary.Left) * zoomFactor * -1 + center.X);
            //int newY = (int)((l.Y - mapBoundary.Top) * zoomFactor * -1 + center.Y);
            int newX = (int)((l.X - 31744) * zoomFactor * -1 + center.X);
            int newY = (int)((l.Y - 30976) * zoomFactor * -1 + center.Y);
            System.Console.WriteLine("newx: " + newX + "   newY:" + newY + "   left:" + mapBoundary.Left + "    top:" + mapBoundary.Top + "   centerX" + center.X + "    centery:" + center.Y);

            imagePos.X = newX;
            imagePos.Y = newY;

            Size tempsizeP = pictureBox.Size;
            Size tempsize = floorImages[currentZ].Size;
            if (imagePos.X > 0)
                imagePos.X = 0;
            if (imagePos.Y > 0)
                imagePos.Y = 0;
            if (imagePos.X < ((-tempsize.Width * zoomFactor) + tempsizeP.Width))
                imagePos.X = (int)((-tempsize.Width * zoomFactor) + tempsizeP.Width);
            if (imagePos.Y < ((-tempsize.Height * zoomFactor) + tempsizeP.Height))
                imagePos.Y = (int)((-tempsize.Height * zoomFactor) + tempsizeP.Height);

            RedrawMap();
        }

        /// <summary>
        /// Get the center of the map in Tibia Coordinates
        /// </summary>
        /// <returns></returns>
        public Location GetMapCenter()
        {
            return PointToMapCoors(GetMapCenterPoint());
        }

        /// <summary>
        /// Draw crosshairs in the middle of the map
        /// </summary>
        public void DrawCrosshairs()
        {
            DrawCrosshairs(GetMapCenterPoint());
        }

        /// <summary>
        /// Draw crosshairs at the specified point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawCrosshairs(int x, int y)
        {
            DrawCrosshairs(new Point(x, y));
        }

        /// <summary>
        /// Draw crosshairs at the specified point
        /// </summary>
        /// <param name="p"></param>
        public void DrawCrosshairs(Point p)
        {
            int x = p.X;
            int y = p.Y;

            // Draw the vertical line
            g.DrawLine(new Pen(Color.White, 1), new Point(x - 5, y), new Point(x + 5, y));
            // Draw the horizontal line
            g.DrawLine(new Pen(Color.White, 1), new Point(x, y - 5), new Point(x, y + 5));
        }

        /// <summary>
        /// Draw a percentage bar on the map
        /// </summary>
        /// <param name="percent"></param>
        public void DrawPercentBar(int percent)
        {
            Font font = new Font("Tahoma", 10, FontStyle.Bold);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            int width = pictureBox.Width / 2;
            int height = font.Height;
            int x = (int)((pictureBox.Width - width) / 2);
            int y = (int)((pictureBox.Height - height) / 2);

            Rectangle outer = new Rectangle(x, y, width, height);

            Rectangle inner = new Rectangle(x + 1, y + 1, (int)((width - 2) * percent / 100.0), height - 2);

            g.FillRectangle(Brushes.Black, outer);
            g.FillRectangle(Brushes.DarkGray, inner);
            g.DrawString(percent + "%", font, Brushes.White, outer, sf);
        }

        /// <summary>
        /// Draw the current coordinates of the center point in the upper right corner
        /// </summary>
        public void DrawCoordinates()
        {
            Location l = GetMapCenter();

            Font font = new Font("Tahoma", 10, FontStyle.Bold);
            Rectangle rect = new Rectangle(pictureBox.Width - 120, 0, 120, font.Height);

            // g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), rect);
            g.FillRectangle(Brushes.Black, rect);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            g.DrawString("" + l.X + ", " + l.Y, font, Brushes.White, rect, sf);
        }

        /// <summary>
        /// Draw a creature on the map
        /// </summary>
        /// <param name="c"></param>
        /// <param name="hpBar">if true the color of the name will be based on the creatures hp bar</param>
        public void DrawCreatureMarker(Creature c, bool hpBar)
        {
            if (hpBar)
                DrawMarker(c.Location, c.Name, Color.Yellow, Color.Black, Color.White, Color.Black, c.HPBar);
            else
                DrawMarker(c.Location, c.Name);
        }

        /// <summary>
        /// Draw a marker with the default colors.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="text"></param>
        public void DrawMarker(Location l, string text)
        {
            DrawMarker(l, text, Color.Yellow, Color.Black);
        }

        /// <summary>
        /// Draw a marker with the default text fill and outline colors.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="text"></param>
        /// <param name="markerFill"></param>
        /// <param name="markerOutline"></param>
        public void DrawMarker(Location l, string text, Color markerFill, Color markerOutline)
        {
            DrawMarker(l, text, markerFill, markerOutline, Color.White, Color.Black);
        }

        public void DrawMarker(Location l, string text, Color markerFill, Color markerOutline, Color textFill, Color textOutline)
        {
            DrawMarker(l, text, markerFill, markerOutline, textFill, textOutline, -1);
        }

        /// <summary>
        /// Draw a marker given the specifications.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="text"></param>
        /// <param name="markerFill"></param>
        /// <param name="markerOutline"></param>
        /// <param name="textFill"></param>
        /// <param name="textOutline"></param>
        /// <param name="hpBar">if hpBar >= 0 && <= 100 draw an HP bar</param>
        public void DrawMarker(Location l, string text, Color markerFill, Color markerOutline, Color textFill, Color textOutline, int hpBar)
        {
            // Convert to Tibia coors
            Point p = MapCoorsToPoint(l);

            // This array of points makes the marker
            Point[] points = {
                new Point(p.X - 8, p.Y - 8),
                new Point(p.X +8, p.Y -8),
                new Point(p.X, p.Y)
            };

            // Anti-aliased for nice effect
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the marker
            g.FillPolygon(new SolidBrush(markerFill), points);
            g.DrawPolygon(new Pen(markerOutline), points);

            // The text font
            Font font = new Font("Tahoma", 8, FontStyle.Bold);

            // The rectangle to hold the text
            Rectangle rect = new Rectangle(p.X - 100,
                p.Y - (font.Height + 7),
                200, font.Height);

            // Center the text
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            // Add "up" or "down" to the name
            if (l.Z != 0 && l.Z != currentZ)
                text += " (" + (currentZ - l.Z > 0 ? "+" : "") + (currentZ - l.Z) + ")";

            // Draw the outlined text
            DrawOutlinedText(text, font, new SolidBrush(textFill), new SolidBrush(textOutline), rect, sf);

            // Draw HP bar if needed
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            if (hpBar >= 0 && hpBar <= 100)
            {
                Rectangle hpOuter = new Rectangle(p.X - 14, p.Y - 27 - 4, 28, 4);
                Rectangle hpInner = new Rectangle(p.X - 13, p.Y - 26 - 4,
                    (int)(hpBar / 100.0 * 26), 2);
                g.FillRectangle(Brushes.Black, hpOuter);
                g.FillRectangle(new SolidBrush(HpPercentToColor(hpBar)), hpInner);
            }
        }

        /// <summary>
        /// Draw the specified text with an outline
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="fill"></param>
        /// <param name="outline"></param>
        /// <param name="rect"></param>
        /// <param name="sf"></param>
        public void DrawOutlinedText(string text, Font font, Brush fill, Brush outline, Rectangle rect, StringFormat sf)
        {
            // Draw the outline by offsetting the rectangle
            rect.Offset(-1, -1);
            g.DrawString(text, font, outline, rect, sf);
            rect.Offset(2, 0);
            g.DrawString(text, font, outline, rect, sf);
            rect.Offset(0, 2);
            g.DrawString(text, font, outline, rect, sf);
            rect.Offset(-2, 0);
            g.DrawString(text, font, outline, rect, sf);

            // Return to the original position and draw the fill
            rect.Offset(1, -1);
            g.DrawString(text, font, fill, rect, sf);
        }
        public static Color HpPercentToColor(int hp)
        {
            int color;
            if (hp >= 95)
                color = 0x00CC00;
            else if (hp >= 60)
                color = 0x60C060;
            else if (hp >= 30)
                color = 0xC0C000;
            else if (hp >= 10)
                color = 0xC03030;
            else if (hp >= 4)
                color = 0xBF0000;
            else if (hp >= 0)
                color = 0x5F0000;
            else
                color = 0;
            return Color.FromArgb((int)(color + 0xFF000000));
        }
    }
}
