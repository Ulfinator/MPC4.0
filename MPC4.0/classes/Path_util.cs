using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC4.classes
{
    public static class Path_util
    {

        public static string get_game_image_path(string path)
        {
            string template_path = System.Configuration.ConfigurationManager.AppSettings["install_path"].ToString() + "game_images\\" + path;
            return template_path;
        }
        /// <summary>
        /// Checks that the image exists on the path and returns the path. If not exist then a no image path is returned
        /// </summary>
        /// <param name="image_name"></param>
        /// <returns></returns>
        public static string check_game_image_path(string image_name)
        {
            string image_path = System.Configuration.ConfigurationManager.AppSettings["install_path"].ToString() + "game_images\\" + image_name;

            if (System.IO.File.Exists(image_path))
                return image_path;
            else
                return System.Configuration.ConfigurationManager.AppSettings["install_path"].ToString() + "App_images\\no_image.jpg";

        }

        /// <summary>
        /// Checks that the creature exist on the path and returns the path, if not exist then a blank path is returned.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string check_creature_save_path(string path)
        {
            string template_path = System.Configuration.ConfigurationManager.AppSettings["install_path"].ToString() + "xml_files\\creature_xml\\" + path;

            if (System.IO.File.Exists(template_path))
                return template_path;
            else
                return "";

        }

        public static string get_creature_save_path(string path)
        {
            string template_path = System.Configuration.ConfigurationManager.AppSettings["install_path"].ToString() + "xml_files\\creature_xml\\" + path;
            return template_path;
        }

        public static string get_encounter_save_path(string path)
        {
            string enc_save_path = System.Configuration.ConfigurationManager.AppSettings["install_path"].ToString() + "xml_files\\creature_xml\\encounter_xml\\" + path;
            return enc_save_path;

        }

        public static string get_application_xml_path(string path)
        {
            string enc_save_path = System.Configuration.ConfigurationManager.AppSettings["install_path"].ToString() + "xml_files\\application_xml\\" + path;
            return enc_save_path;

        }

        public static string get_body_modle_path(string path)
        {
            string enc_save_path = System.Configuration.ConfigurationManager.AppSettings["install_path"].ToString() + "xml_files\\body_modles_xml\\" + path;
            return enc_save_path;

        }
        public static string get_euipment_path(string path)
        {
            string enc_save_path = System.Configuration.ConfigurationManager.AppSettings["install_path"].ToString() + "xml_files\\equipment\\" + path;
            return enc_save_path;

        }

        public static string get_armour_path(string path)
        {
            string enc_save_path = System.Configuration.ConfigurationManager.AppSettings["install_path"].ToString() + "xml_files\\arms_and_armour\\" + path;
            return enc_save_path;

        }

    }
}
