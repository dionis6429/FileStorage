using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Data.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool IsNew
        {
            get
            {
                return this.Id <= 0;
            }
        }
    }
}
