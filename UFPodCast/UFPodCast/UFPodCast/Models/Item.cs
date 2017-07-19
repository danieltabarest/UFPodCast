using System;

namespace UFPodCast.Models
{
    public class Item : BaseDataObject
    {
        //string text = string.Empty;
        //public string Text
        //{
        //    get { return text; }
        //    set { SetProperty(ref text, value); }
        //}

        public int ID_PODCAST { get; set; }
        public int ID_AUTOR { get; set; }
        public int ID_CATEGORIA { get; set; }
        public int N_NUMERO { get; set; }
        public string S_NOMBRE { get; set; }
        public string S_DESCRIPCION { get; set; }
        public string S_PALABRASCLAVE { get; set; }
        public DateTime D_GRABACION { get; set; }
        public string S_NOMBREARCHIVO { get; set; }
        public string S_RUTAARCHIVO { get; set; }
        public string S_RUTAIMAGENPODCAST { get; set; }
        public bool B_ESTADO { get; set; }
        public string S_CATEGORIA { get; set; }
        public string S_AUTOR { get; set; }
        public string S_EMAIL_AUTOR { get; set; }


    }
}
