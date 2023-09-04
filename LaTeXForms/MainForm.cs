using CSharpMath.Rendering.FrontEnd;
using CSharpMath.SkiaSharp;
using SkiaSharp;

namespace LaTeXForms;

// rem https://github.com/verybadcat/CSharpMath/issues/226

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

        var imageInfo = new SKImageInfo(p.Width, p.Height);
        using var surface = SKSurface.Create(imageInfo);

        using var canvas = surface.Canvas;

        var painter = new MathPainter {
            LaTeX = @"\frac\sqrt23"
        };

        painter.Draw(canvas);

        using var snapshot = surface.Snapshot();
        using var image = snapshot.Encode(SKEncodedImageFormat.Png, 100);
        using var stream = new MemoryStream(image.ToArray());
        p.Image = new Bitmap(stream, false);
    }
}