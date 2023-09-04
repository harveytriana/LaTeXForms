
using CSharpMath.SkiaSharp;
using SkiaSharp;

namespace LaTeXForms;

// Sample for CSharpMath
// https://github.com/verybadcat/CSharpMath
// report document 
// https://github.com/verybadcat/CSharpMath/issues/226

public partial class MainForm : Form
{
    readonly string[] samples = new string[] {
        @"\frac{-b \pm \sqrt{b^2 + 4ac}}{2a}",
        @"\frac\sqrt23",
        @"e^{i \pi}",
        @"\int_{a}^{b} u dv = u(x)v(x)|_a^b - \int^{b}_a v du"
    };

    public MainForm()
    {
        InitializeComponent();

        DrawSample(3);
    }

    private void DrawSample(int sampleIndex)
    {
        PictureBox p = pictureBox; // exists a PictureBox with name pictureBox

        // create canvas
        var imageInfo = new SKImageInfo(p.Width, p.Height);
        using var surface = SKSurface.Create(imageInfo);
        using var canvas = surface.Canvas;

        // draw LaTeX 
        var painter = new MathPainter {
            LaTeX = samples[sampleIndex],
        };
        painter.Draw(canvas);

        // transfer skia image to PictureBox
        using var snapshot = surface.Snapshot();
        using var image = snapshot.Encode(SKEncodedImageFormat.Png, 100);
        using var stream = new MemoryStream(image.ToArray());
        p.Image = new Bitmap(stream, false);
    }
}