using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmGateDev.Models
{
    public class CheckList
    {
        public string road { get; set; }
        public string council { get; set; }
        public int lengthkm { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime accesslastdate { get; set; }
        public string assessor { get; set; }
        public Questions[] questions { get; set; }
        public CheckList(string roadVal, string councilVal, int lengthkmVal, DateTime accesslastdateVal, string assessorVal, Questions[] questionArray)
        {
            road = roadVal;
            council = councilVal;
            lengthkm = lengthkmVal;
            accesslastdate = accesslastdateVal;
            assessor = assessorVal;
            questions = questionArray;
        }
      
    }

    public class Questions
    {
        public string group { get; set; }
        public string describe { get; set; }
        public string selection { get; set; }
        public string risk { get; set; }
        public string riskflag { get; set; }
        public string measure { get; set; }
        public string residual { get; set; }
        public string residualflag { get; set; }
        public Questions(string groupVal, string describeVal, string selectionVal, string riskVal, string riskFlagVal, string measureVal, string residualVal, string residualFlagVal)
        {
            group = groupVal;
            describe = describeVal;
            selection = selectionVal;
            risk = riskVal;
            riskflag = riskFlagVal;
            measure = measureVal;
            residual = residualVal;
            residualflag = residualFlagVal;
        }

        public Questions()
        {
            group = "";
            describe = "";
            selection = "";
            risk = "";
            riskflag = "";
            measure = "";
            residual = "";
            residualflag = "";
        }

    }

}
