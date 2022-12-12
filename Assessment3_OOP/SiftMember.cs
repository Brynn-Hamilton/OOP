using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3_OOP
{
    // Create a class called SiftMember with the following properties
    // Name, Anniversary Date (DateTime), Job Title, Email, List of skills (string)
        public class SiftMember
        {
            public string Name;
            public DateTime AnniversaryDate;
            public string JobTitle;
            public string Email;
            public List<string> Skills;

        // Pass through above listed variables to construct new SiftMember object
            public SiftMember(string name, DateTime anniversaryDate, string jobTitle, string email, List<string> skills)
            {
                Name = name;
                AnniversaryDate = anniversaryDate;
                JobTitle = jobTitle;
                Email = email;
                Skills = skills;
            }

        // Add Skill method
        // return true if non-duplicate skill has been successfully added to the list
        // else it returns false
            public bool AddSkill(string newSkill)
            {
                if (Skills.Contains(newSkill))
                {
                    return false;
                }
                else
                {
                    Skills.Add(newSkill);
                    return true;
                }
            }

        // Override ToString() to print a Sift Member as seen in the sample output
            public override string ToString()
            {
                return $"Name: {Name} \nJob Title: {JobTitle} \nAnniversary: {AnniversaryDate.ToShortDateString()} \nEmail: {Email} \nSkills: {string.Join(", ", Skills)}\n";
            }
        }
    }
