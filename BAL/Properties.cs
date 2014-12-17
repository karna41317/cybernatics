using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL
{
    public class Properties
    {
        
        public int UserId { get; set; }


        public int AgencyId { get; set; }

        public int AgentId { get; set; }

        public int CaseId { get; set; }

        public string LoginId { get; set; }

        
        public string PassWord { get; set; }

        
        public string NewPassWord { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public DateTime DateOfBirth { get; set; }

        
        public string Address { get; set; }

        
        public string EmailId { get; set; }

        
        public string ContactNo { get; set; }

        
        public byte[] FileContent { get; set; }

        
        public string FileName { get; set; }

        
        public string HintQuestion { get; set; }

        
        public string Answer { get; set; }

        public string CaseName { get; set; }

        public string Description { get; set; }
    }
}
