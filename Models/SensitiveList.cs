﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flash.Test.Models
{
    public partial class SensitiveList
    {
        [Key]
        public long RowId { get; set; }
        public string SensitiveWord { get; set; }
    }
}