using System;
using SMSGATEWAY.Core.Models;

namespace SMSGATEWAY.DOMAIN.Models
{
    public class VendorBillingSetup : EntityAudit
    {
        protected VendorBillingSetup()
        {
        }

        public VendorBillingSetup(bool masking, double perSmsRate, DateTime startDate, DateTime endDate, Guid vendorId)
        {
            Masking = masking;
            PerSmsRate = perSmsRate;
            StartDate = startDate;
            EndDate = endDate;
            VendorId = vendorId;
        }

        public bool Masking { get; private set; }
        public double PerSmsRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Guid VendorId { get; private set; }

        public virtual VendorInfo VendorInfo { get; private set; }
    }
}