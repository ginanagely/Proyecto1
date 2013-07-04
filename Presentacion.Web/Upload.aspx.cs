using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Presentacion.Web
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nombre del archivo
            string fileName = string.Empty;

            try
            {

                if (Request.QueryString["n"] != null)
                    fileName = Request.QueryString["n"];
                else
                    return;

                Stream inputStream = Request.InputStream;
                byte[] bytes = new byte[inputStream.Length];

                //Guarda el archivo en el fólder ClientBin
                StreamWriter sw = new StreamWriter(Server.MapPath("/Data/") + fileName);
                BinaryWriter bw = new BinaryWriter(sw.BaseStream);
                inputStream.Read(bytes, 0, bytes.Length);
                bw.Write(bytes);
                bw.Flush();
                bw.Close();

            }
            catch (Exception) { throw; }
        }
    }
}