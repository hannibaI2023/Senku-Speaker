using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Management.Automation;

namespace boku_no_speaker
{
    public partial class Form1 : Form
    {
        //declare for English
        string Number = "";
        string[] Buff = new string[] {
            "", "thousand", "million", "billion",
            "trillion", "quadrillion", "quintillion" };
        string[] Small = new string[] {
            "","one", "two", "three", "four", "five",
            "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve"};
        string[] Prefix = new string[] {
            "", "", "twen", "thir", "four", "fif",
            "six", "seven", "eigh", "nine" };
        //read for English
        SpeechSynthesizer mouth = new SpeechSynthesizer();
        //
        public Form1()
        {
            InitializeComponent();
        }
        //English part
        string writesubnum(string subnum)//read blocks of 3 digits numbers (abb)
        {
            string result = "";
            int realnum = Int32.Parse(subnum);
            //
            if (realnum < 13)
                return Small[realnum];
            //Read a
            int a = realnum / 100;
            if (a != 0)
            {
                result = Small[a] + " " + "hundred";
            }
            //Read bb
            int b = realnum % 100;
            string resb = "";
            if (b != 0)
            {
                if (b < 13)
                    resb = Small[b];
                else if (b < 20)
                    resb = Prefix[b % 10] + "teen";
                else //b>20
                {
                    if ((int)(b / 10) == 4)//stupid English
                        resb = "forty-" + Small[b % 10];
                    else if (b % 10 != 0)
                        resb = Prefix[(int)(b / 10)] + "ty-" + Small[b % 10];
                    else
                        resb = Prefix[(int)(b / 10)] + "ty";
                }
                if (result != "")
                    result = result + " and " + resb;
                else
                    result = resb;
            }
            return result;
        }

        string writeEnglish()//read whole number : English
        {
            if (Number == "0")
                return "zero";
            //
            int level = 0;
            string endwrite = "";
            bool negative = false;
            if (Number[0] == '-')
            {
                negative = true;
                Number = Number.Remove(0, 1);
            }
            for (int i = Number.Length - 3; i >= -2; i -= 3)//blocks of 3 (abb)
            {
                string subnum = "";
                if (i < 0)//in case it doesn't fit
                    subnum = Number.Substring(0, 3 - Math.Abs(i));
                else
                    subnum = Number.Substring(i, 3);
                string subwrite = writesubnum(subnum);
                if (subwrite != "")
                    endwrite = subwrite + " " + Buff[level] + " " + endwrite;
                //in case it fits
                if (i == 0)
                    return endwrite;
                //
                ++level;
            }
            if (negative)
                endwrite = "Negative " + endwrite;
            else endwrite = char.ToUpper(endwrite[0]) + endwrite.Substring(1);

            return endwrite;
        }
        //end of English part

        //Vietnamese part 
        public static string NumberToText(string inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            string sNumber = inputNumber;
            double number = Convert.ToDouble(inputNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "mốt " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "linh " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result;
        }

        //driver code
        private void execute_Click(object sender, EventArgs e)
        {
            Number = Input.Text;
            if (comboBox1.Text == "Tiếng Việt")
            {
                try
                {
                    output.Text = boku_no_speaker.Form1.NumberToText(Number);
                    try
                    {
                        mouth.SelectVoice("Microsoft An");
                        mouth.SpeakAsync(output.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Bạn chưa cài đặt Language Pack Tiếng Việt!", "XẢY RA LỖI");
                    }
                }
                catch//If number too big
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "XẢY RA LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //if (English.Checked == true)
            {
                try
                {
                    output.Text = writeEnglish();
                    mouth.SelectVoice("Microsoft David");
                    mouth.SpeakAsync(output.Text);
                }
                catch//If number too big
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "XẢY RA LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy cài đặt Microsoft Language Pack Tiếng Việt để đọc Tiếng Việt.","CẢNH BÁO");
            //add stuff to combo box
            comboBox1.Items.Add("Tiếng Việt");
            comboBox1.Items.Add("English");
            //"unlock" VN pack
            string scriptinstallvi = @"
            $sourcePath = 'HKLM:\software\Microsoft\Speech_OneCore\Voices\Tokens' #Where the OneCore voices live
            $destinationPath = 'HKLM:\SOFTWARE\Microsoft\Speech\Voices\Tokens' #For 64-bit apps
            $destinationPath2 = 'HKLM:\SOFTWARE\WOW6432Node\Microsoft\SPEECH\Voices\Tokens' #For 32-bit apps
            cd $destinationPath
            $listVoices = Get-ChildItem $sourcePath
            foreach($voice in $listVoices)
            {
                $source = $voice.PSPath #Get the path of this voices key
                copy -Path $source -Destination $destinationPath -Recurse
                copy -Path $source -Destination $destinationPath2 -Recurse
            }
            ";
            PowerShell ps1 = PowerShell.Create();
            ps1.AddScript(scriptinstallvi);
            ps1.Invoke();
        }
        //end of driver code
    }
}
