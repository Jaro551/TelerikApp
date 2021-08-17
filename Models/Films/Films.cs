using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleTelerikApp.Models
{
    [MetadataType(typeof(FilmsMetaData))]
    public partial class Films
    {

    }
    public class FilmsMetaData
    {
        public int ID { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Reżyser")]
        public string Director { get; set; }
        [Display(Name = "Data wydania")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
    }
}