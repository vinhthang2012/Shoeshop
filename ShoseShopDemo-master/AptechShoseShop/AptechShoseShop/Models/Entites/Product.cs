using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AptechShoseShop.Models.Entites
{
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductColors = new HashSet<ProductColor>();
           
            ProductSizes = new HashSet<ProductSize>();
            Images = "~/Content/images/1.jpg";
           
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public double DiscountRatio { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/mm/yyyy}")]
        public DateTime DiscountExpiry { get; set; }
        public int CategoryId { get; set; }
        public string Images { get; set; }
        public int? ProductImageId { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/mm/yyyy}")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int StatusId { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual Category Category { get; set; }
        public virtual TbUser CreatedByNavigation { get; set; }
        
        public virtual StatusProduct Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
       
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}