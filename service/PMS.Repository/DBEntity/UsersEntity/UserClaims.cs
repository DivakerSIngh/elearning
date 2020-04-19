﻿namespace PMS.Repository
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserClaims: IdentityUserClaim
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
