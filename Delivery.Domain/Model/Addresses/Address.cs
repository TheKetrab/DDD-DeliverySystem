using Delivery.Generic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Domain.Model.Addresses
{
    public class Address : Entity
    {
        public override int Id { get; set; }
        public virtual Nation Nation { get; set; }
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual string Nr { get; set; }
        public virtual string ZipCode { get; set; }

        public override string ToString()
        {
            return
                string.Format("{0}, {1}, {2}, {3}",
                    ZipCode, City, Street, Nr
                );

        }

        public override bool Equals(Object obj)
        {
            if (obj is Address)
            {
                var that = obj as Address;
                return this.Id == that.Id
                    && this.Nation.Id == that.Nation.Id
                    && this.City == that.City
                    && this.Street == that.Street
                    && this.Nr == that.Nr
                    && this.ZipCode == that.ZipCode
                    ;
            }

            return false;
        }
    }
}
