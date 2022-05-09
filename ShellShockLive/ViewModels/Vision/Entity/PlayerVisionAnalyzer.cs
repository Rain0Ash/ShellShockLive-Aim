// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Threading.Tasks;
using NetExtender.Types.Monads;
using NetExtender.Utilities.Types;
using NetExtender.Windows.Types;
using ShellShockLive.ViewModels.Vision.Bindings;

namespace ShellShockLive.ViewModels.Vision
{
    public class PlayerVisionAnalyzer : ColorVisionAnalyzer<Point>
    {
        protected override PlayerVisionTemplate Template { get; }

        public PlayerVisionAnalyzer()
            : this(null)
        {
        }

        public PlayerVisionAnalyzer(PlayerVisionTemplate? template)
        {
            Template = template ?? new PlayerVisionTemplate();
        }

        public override Task<Maybe<Point>> AnalyzeAsync(Rectangle screen, DirectBitmap bitmap, VisionBinding binding)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            if (binding is null)
            {
                throw new ArgumentNullException(nameof(binding));
            }
            
            return TaskUtilities<Maybe<Point>>.Default;

            /*Rectangle rectangle = binding.Player.Screen;
            rectangle = new Rectangle(rectangle.X, rectangle.Y, Math.Min(bitmap.Width, rectangle.Width), Math.Min(bitmap.Height, rectangle.Height));
            using Bitmap game = bitmap.Clone(rectangle);
            using OpenCvSharp.Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(game);
            OpenCvSharp.Cv2.CvtColor(mat, mat, OpenCvSharp.ColorConversionCodes.RGB2BGR);
            using OpenCvSharp.Mat mask = new OpenCvSharp.Mat();
            OpenCvSharp.Cv2.InRange(mat, new OpenCvSharp.Scalar(200, 0, 0), new OpenCvSharp.Scalar(255, 75, 75), mask);
            OpenCvSharp.Cv2.ImShow("Test", mask);
            OpenCvSharp.Cv2.WaitKey();

            return TaskUtilities<Maybe<Point>>.Default;

            ColorPoint[] array = await Template.Template.PointsInAsync(bitmap.GetEnumerator(rectangle)).ConfigureAwait(false);

            if (array.Length <= Template.Template.Limit)
            {
                return default;
            }

            ConcurrentPointsContainer points = new ConcurrentPointsContainer(array.Length);
            Parallel.ForEach(array, center =>
            {
                PointContainer container = points.GetOrAdd(center, new PointContainer(center, binding.Player.Player, array.Length));
                Parallel.ForEach(array, point => container.Add(point));
            });

            Point center = Point.Empty;
            PointContainer container = points.Values.MaxByOrDefault(pair => pair.Count, () => new PointContainer(Point.Empty, Size.Empty, 0));
            foreach (Point point in container)
            {
                center.Offset(point);
#if DEBUG
                bitmap.TrySetPixel(point, Color.Black);
#endif
            }

            center = new Point(center.X / (container.Count - 1), center.Y / (container.Count - 1));

            center.Offset(screen.X, screen.Y);

#if DEBUG
            bitmap.TrySetPixel(center, Color.White);
#endif*/
            /*return center;*/
        }
    }
}