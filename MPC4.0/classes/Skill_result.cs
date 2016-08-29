namespace MPC4.classes
{
    public class Skill_result
    {
        string result;
        int die_value;
        int modified_skill_value;
        int skill_die_diff;
        string extra_info;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        public int Die_value
        {
            get { return die_value; }
            set { die_value = value; }
        }

        public int Modified_skill_value
        {
            get { return modified_skill_value; }
            set { modified_skill_value = value; }
        }

        public string Extra_info
        {
            get { return extra_info; }
            set { extra_info = value; }
        }

        public int Skill_die_diff
        {
            get { return skill_die_diff; }
            set { skill_die_diff = value; }
        }
    }
}
