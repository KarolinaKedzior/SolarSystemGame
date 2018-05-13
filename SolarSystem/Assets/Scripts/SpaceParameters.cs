using UnityEngine;
using System.Collections;

public static class SpaceParameters  {

    public static double
        G = 6.6726 * Mathd.Pow(10, -11),
        G_N = 0.000000000888944023114755,
        LY = 9.4605 * Mathd.Pow(10, 15),
        PC = 3.2616 * LY,
        AU = 1.49599 * Mathd.Pow(10, 11),//149597871000f, // meter
        AU_N = 1,

        E_M_DISTANCE = 3.84 * Mathd.Pow(10, 8),
        NE_E_M_DISTANCE = E_M_DISTANCE / AU,
        E_g = 9.80665,

        E_MASS = 5.975 * Mathd.Pow(10, 24),
        M_MASS = 7.347 * Mathd.Pow(10, 22),
        S_MASS = 1.989 * Mathd.Pow(10, 30),


        E_MASS_N = 1,
        M_MASS_N = M_MASS / E_MASS,
        S_MASS_N = S_MASS / E_MASS,

        E_YEAR = 365.2564, // DAYS
        E_DAY = 8.64 * Mathd.Pow(10, 4),//seconds
        E_DAY_N = 1,

        E_SPEED = 297800,
        E_SPEED_N = 0.0171992593533379;
        public static int 
        EARTH_R = 6371,
        MOON_R = 1738 ,
        SUN_R = 696000  // km
        ;

    public static System.DateTime a;
      //  E_DAY = new System.DateTime(0, 0, 0, 23, 56, 4), 
      //  M_DAY = new System.DateTime(0, 0, 27, 7, 43, 11);
        



    //Nachylenie równika do ekliptyki 	 = 2326’21”,448
//(płaszczyzny orbity Ziemi)

}
