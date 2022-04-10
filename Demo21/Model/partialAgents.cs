using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Demo21.Model
{
    partial class Agents
    {
        public byte[] LogoTip
        {
            get
            {
                if (File.Exists($"logo/{Logo}"))
                { return File.ReadAllBytes($"logo/{Logo}"); }
                return null;
            }
        }
        public string CountRealization
        {
            get
            {
                int sum = ProductRealization.Sum(s => s.Count);

                return sum.ToString() + " продаж за год";
            }
        }
        public string TypeNameAgents
        {
            get
            {
                return $"{AgentTypes.TypeName} | {NameCompany}";
            }
        }
        public string PriorityZnach
        {
            get
            {
                return $"Приоритетность: {Priority}";

            }
        }
        public int Skidka
        {
            get
            {
                decimal sum = (decimal)ProductRealization.Sum(s => s.Count * s.Products.PriceMin);
                if (sum < 10000) { return 0; }
                if (sum >= 10000 && sum < 50000) { return 5; }
                if (sum >= 50000 && sum < 150000) { return 10; }
                if (sum >= 150000 && sum < 500000) { return 20; }
                return 25;
            }
        }
        public string AType
        {
            get
            {
                return $"{AgentTypes.TypeName}";
            }
        }
    }
}
