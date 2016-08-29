using System;
using System.Xml;
using System.Collections.Generic;
using System.Drawing;

namespace MPC4.classes
{
    public static class Creature_drawing_handler
    {
        public static void draw_body(Body_modle body_mod, Color back_color, ref Graphics graph)
        {
            graph.Clear(back_color);

            if (body_mod == null)
                return;

            foreach (Body_part bp in body_mod.Body_parts)
            {
                if (bp.Status == "WOUNDED")
                    fill_polygon(bp.Draw_points, new SolidBrush(Color.LightGray), ref graph);
                else if (bp.Status == "DESTROYED")
                    fill_polygon(bp.Draw_points, new SolidBrush(Color.Black), ref graph);
                else
                    draw_polygon(bp.Draw_points, new Pen(Color.Black, 2F), ref graph);

                // Add Hit die value
                if (bp.Die_text_point != null)
                {
                    if (bp.Hit_die_start == bp.Hit_die_end)
                        draw_text(bp.Hit_die_start.ToString(), bp.Die_text_point, ref graph);
                    else
                        draw_text(bp.Hit_die_start.ToString() + "-" + bp.Hit_die_end.ToString(), bp.Die_text_point,ref graph);
                }
            }
        }

        public static void draw_polygon(List<Point> draw_points, Pen p, ref Graphics graph)
        {
            Point[] pnt = draw_points.ToArray();

            if (pnt.Length > 0)
                graph.DrawPolygon(p, pnt);
        }

        public static void fill_polygon(List<Point> draw_points, SolidBrush b, ref Graphics graph)
        {
            Point[] pnt = draw_points.ToArray();

            if (pnt.Length > 0)
                graph.FillPolygon(b, pnt);
        }

        public static void draw_text(string text, Point p, ref Graphics graph)
        {
            graph.DrawString(text,
                new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                new SolidBrush(Color.Black), p);
        }

        public static bool IsInPolygon(Point[] poly, Point p)
        {
            Point p1, p2;
            bool inside = false;

            if (poly.Length < 3)
                return inside;

            Point oldPoint = new Point(
                poly[poly.Length - 1].X, poly[poly.Length - 1].Y);


            for (int i = 0; i < poly.Length; i++)
            {
                Point newPoint = new Point(poly[i].X, poly[i].Y);

                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }

                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }


                if ((newPoint.X < p.X) == (p.X <= oldPoint.X)
                    && (p.Y - (long)p1.Y) * (p2.X - p1.X)
                    < (p2.Y - (long)p1.Y) * (p.X - p1.X))
                {
                    inside = !inside;
                }

                oldPoint = newPoint;
            }

            return inside;
        }

        public static void fill_circle(Point p, SolidBrush b, ref Graphics graph, Size sz)
        {
            Rectangle rect = new Rectangle(p, sz);

            graph.FillEllipse(b, rect);
        }

        public static XmlElement create_draw_point_xml(List<System.Drawing.Point> point_list, ref XmlDocument xDoc)
        {
            XmlElement draw_points = xDoc.CreateElement("drawing_points");

            foreach (System.Drawing.Point dp in point_list)
            {
                XmlElement point = xDoc.CreateElement("point");
                point.AppendChild(Xml_util.create_text_element("x", Convert.ToString(dp.X), ref xDoc));
                point.AppendChild(Xml_util.create_text_element("y", Convert.ToString(dp.Y), ref xDoc));

                draw_points.AppendChild(point);
            }

            return draw_points;
        }

        public static void clear_area(Graphics graph, Color back_color)
        {
            graph.Clear(back_color);
        }

    }
}
