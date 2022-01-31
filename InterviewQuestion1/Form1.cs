using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InterviewQuestion1
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> WebSiteData = new Dictionary<string, string>(); // Setup Dictonary Map

        public Form1()
        {
            InitializeComponent();

            //Hide Output Data text
            lblOutputData.Text = "";

            //Hide Loading Text
            lblLoading.Visible = false; // hide loading lable

            //Init Keys to Dictonary
            WebSiteData.Add("name", ""); // Key , DataVal
            WebSiteData.Add("type", ""); // Key , DataVal
            WebSiteData.Add("issuer", ""); // Key , DataVal
            WebSiteData.Add("isin", ""); // Key , DataVal
            WebSiteData.Add("classType", ""); // Key , DataVal
            WebSiteData.Add("price", ""); // Key , DataVal
            WebSiteData.Add("daily_movement", ""); // Key , DataVal
            WebSiteData.Add("morning_star_rating", ""); // Key , DataVal   
        }

        private void BtnGet_Click(object sender, EventArgs e)
        {
            lblLoading.Visible = true; // Show loading lable
            GetDataFromWebsite(); // Connect to Website and extract data        
        }

        private void GetDataFromWebsite() // Connect to Website and extract data
        {
            // Data to be populated
            string name;
            string type;
            string issuer;
            string isin;
            string classType;
            string price;
            string daily_movement;
            int morning_star_rating;

            // Variables to get the Info from the Extracted string
            int StartIndex; // Starting place of the String
            int LengthOfString; // Length of the string

            try
            {
                string TheURL = "https://www.investing.com/funds/allan-gray-balanced-fund-c-chart"; // Website to be connected to

                HtmlAgilityPack.HtmlWeb Website = new HtmlAgilityPack.HtmlWeb(); // Connect to Website
                HtmlAgilityPack.HtmlDocument GetDocData = Website.Load(TheURL); // GEt Data from Website

                // Store Extracted Text into DataList
                var dataList1 = GetDocData.DocumentNode.SelectNodes("//div[@class='instrumentHead']").ToList(); // Get Name
                var dataList2 = GetDocData.DocumentNode.SelectNodes("//div[@class='right general-info']").ToList(); // Get Type, Issuer, ISIN, Asset Class
                var dataList3 = GetDocData.DocumentNode.SelectNodes("//span[@id='last_last']").ToList(); // Get Price
                var dataList5 = GetDocData.DocumentNode.SelectNodes("//div[@class='inlineblock']").ToList(); // Get Daily_Movement
                var dataList4 = GetDocData.DocumentNode.SelectNodes("//span[@class='morningStarsWrap']").ToList(); // Get Star Rating 

                // Get Name Data 
                StartIndex = dataList1[0].InnerText.IndexOf("\n") + 1; // Get Starting position of Name
                name = dataList1[0].InnerText.Substring(StartIndex, 50).Trim(); // Get String 
                name = name.Replace("\n", "");
                name = name.Replace("&nb", "");

                // Get Type Data
                StartIndex = dataList2[0].InnerText.IndexOf("Type:&nbsp;") + 11; // Get Starting position of type
                type = dataList2[0].InnerText.Substring(StartIndex, 20).Trim(); // Get String 
                type = type.Replace("\n", ""); // Remove any unnecessary Data
                type = type.Replace("Market:", ""); // Remove any unnecessary Data
                type = type.Replace("&nbsp", ""); // Remove any unnecessary Data

                // Get Issuer Data
                StartIndex = dataList2[0].InnerText.IndexOf("Issuer:&nbsp;") + 13; // Get Starting position of Issuer
                issuer = dataList2[0].InnerText.Substring(StartIndex, 50).Trim(); // Get String 
                issuer = issuer.Replace("\n", ""); // Remove any unnecessary Data            
                issuer = issuer.Replace("ISIN:", ""); // Remove any unnecessary Data 
                issuer = issuer.Replace("&nbsp;", ""); // Remove any unnecessary Data
                issuer = issuer.Replace("ZAE00017", ""); // Remove any unnecessary Data

                // Get ISIN Data
                StartIndex = dataList2[0].InnerText.IndexOf("ISIN:&nbsp;") + 11;  // Get Starting position of ISIN
                isin = dataList2[0].InnerText.Substring(StartIndex, 20).Trim(); // Get String 
                issuer = issuer.Replace("\n", ""); // Remove any unnecessary Data 
                isin = isin.Replace("Asset Class:", "");// Remove any unnecessary Data
                isin = isin.Replace("&nbsp;", "");// Remove any unnecessary Data

                // Get Asset Class Data
                StartIndex = dataList2[0].InnerText.IndexOf("Class:&nbsp;") + 1; // Get Starting position of Asset Class
                LengthOfString = dataList2[0].InnerText.IndexOf("&nbsp;", StartIndex) - StartIndex;
                classType = dataList2[0].InnerText.Substring(143, LengthOfString + 3); // Get String 
                classType = classType.Replace(";\n", ""); // Remove any unnecessary Data

                // Get Price Data 
                price = dataList3[0].InnerText.Trim(); // Get Spicific price from website

                // Get Daily Movement Data 
                StartIndex = dataList5[0].InnerText.IndexOf("&nbsp;&nbsp;") + 12;  // Get Starting position of Daily Movement
                daily_movement = dataList5[0].InnerText.Substring(StartIndex, 10).Trim(); // Get String 
                daily_movement = daily_movement.Replace("\n", ""); // Remove Spaces between lines

                // Get Morning Star Rating Data 
                morning_star_rating = dataList4[0].InnerHtml.Count(c => c == 'D'); // Count Total of dark stars to get the Rating

                PopulateDictonary(name, type, issuer, isin, classType, price, daily_movement, morning_star_rating.ToString()); // Send data to dictonary to be mapped

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void PopulateDictonary(string name, string type, string issuer, string isin, string classType, string price, string daily_movement, string morning_star_rating)
        {
            // Insert Values into Dictonary
            WebSiteData["name"] = name; // Insert name Value
            WebSiteData["type"] = type; // Insert type Value
            WebSiteData["issuer"] = issuer; // Insert issuer Value
            WebSiteData["isin"] = isin; // Insert isin Value
            WebSiteData["classType"] = classType; // Insert classType Value
            WebSiteData["price"] = price; // Insert price Value
            WebSiteData["daily_movement"] = daily_movement; // Insert daily_movement Value
            WebSiteData["morning_star_rating"] = morning_star_rating; // Insert morning_star_rating Value

            lblLoading.Visible = false; // hide loading lable

            // Print to screen
            lblOutputData.Text = WebSiteData["name"] + "\n"
                                 + WebSiteData["type"] + "\n"
                                 + WebSiteData["issuer"] + "\n"
                                 + WebSiteData["isin"] + "\n"
                                 + WebSiteData["classType"] + "\n"
                                 + WebSiteData["price"] + "\n"
                                 + WebSiteData["daily_movement"] + "\n"
                                 + WebSiteData["morning_star_rating"] + "\n";

        }

        private void lblAssetClass_Click(object sender, EventArgs e)
        {

        }

        private void lblMorningStarRating_Click(object sender, EventArgs e)
        {

        }

        private void lblDailyMovement_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
