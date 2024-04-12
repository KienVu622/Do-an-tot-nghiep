namespace QLBQA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public int ImageID { get; set; }


        public string Path { get; set; }

        public string Description { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
