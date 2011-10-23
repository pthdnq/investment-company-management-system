using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Drawing.Imaging;

namespace ExtAspNet.Examples.basic.Captcha
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class captcha : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            int width = 200;
            int height = 30;

            try
            {
                width = Convert.ToInt32(context.Request.QueryString["w"]);
                height = Convert.ToInt32(context.Request.QueryString["h"]);
            }
            catch (Exception)
            {
                // Nothing
            }

            // Create a CAPTCHA image using the text stored in the Session object.
            CaptchaImage.CaptchaImage ci = new CaptchaImage.CaptchaImage(context.Session["CaptchaImageText"].ToString(), width, height, "Consolas");

            // Change the response headers to output a JPEG image.
            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";

            // Write the image to the response stream in JPEG format.
            ci.Image.Save(context.Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
