
using CSharpMath.SkiaSharp;
using SkiaSharp;

namespace LaTeXForms;

// Sample for CSharpMath
// https://github.com/verybadcat/CSharpMath
// report document 
// https://github.com/verybadcat/CSharpMath/issues/226

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        DrawSample();
    }

    private void DrawSample()
    {
        var p = pictureBox; // exists a PictureBox with name pictureBox

        // create canvas
        var imageInfo = new SKImageInfo(p.Width, p.Height);
        using var surface = SKSurface.Create(imageInfo);
        using var canvas = surface.Canvas;

        // draw LaTeX 
        var painter = new MathPainter {
            LaTeX = @"\frac\sqrt23"
        };
        painter.Draw(canvas);

        // transfer skia image to PictureBox
        using var snapshot = surface.Snapshot();
        using var image = snapshot.Encode(SKEncodedImageFormat.Png, 100);
        using var stream = new MemoryStream(image.ToArray());
        p.Image = new Bitmap(stream, false);
    }
}