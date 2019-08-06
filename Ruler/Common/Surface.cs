using System.Drawing;
using System.Windows.Forms;

namespace Ruler.Common
{
    public abstract class Surface : Form, IElement
    {
        protected static Graphics Graphics;

        protected Surface(PaintEventArgs e)
        {
            Graphics = e.Graphics;
        }
        
        public virtual void Draw()
        {
        }
    }
}