using System;

namespace UFPodCast.Models
{
    public class Category : BaseDataObject
    {
            public object[] PODCAST { get; set; }
            public int ID_CATEGORIA { get; set; }
            public string S_NOMBRE { get; set; }
            public object S_DESCRIPCION { get; set; }
            public string S_RUTAIMAGENCATEGORIA { get; set; }
            public bool B_ESTADO { get; set; }
    }
}
