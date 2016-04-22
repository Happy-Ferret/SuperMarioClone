/*
 * ****************************************************************************
 *  Super Mario Clone
 *      Tilengine based super mario implementation, written in C#
 *      Marc Palacios, 2016
 * ****************************************************************************
*/

using Tilengine;

/// <summary>
/// Manages the game HUD
/// </summary>
struct HUD
{
    const int fontWhite = 11;
    const int fontYellow = 22;

    static Field field;

    /// <summary>
    /// Setup HUD resources
    /// </summary>
    public static void Init ()
    {
        field = new Field(Game.LayerHUD, "smw_hud", "Layer 1");
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    public static void Deinit()
    {
        field.Delete();
    }
    
    /// <summary>
    /// Update lives counter
    /// </summary>
    public static void ShowLives(int value)
    {
        print(fontYellow, string.Format("{0,2}",value), 3, 12);
    }

    /// <summary>
    /// Updates time counter
    /// </summary>
    public static void ShowTime(int value)
    {
        print(fontYellow, string.Format("{0,3}",value), 3, 28);
    }

    /// <summary>
    /// Updates coins counter
    /// </summary>
    public static void ShowCoins(int value)
    {
        print(fontWhite, string.Format("{0,3}",value), 2, 36);
    }

    /// <summary>
    /// Updates score counter
    /// </summary>
    public static void ShowScore(int value)
    {
        print(fontWhite, string.Format("{0,5}",value), 3, 34);
    }

    static void print(int font, string text, int row, int col)
    {
        char[] chars = text.ToCharArray();
        foreach (char c in chars)
        {
            if (c == ' ')
                field.ClearTile(row, col);
            else
                field.SetTile(row, col, (ushort)(font + c - 0x30));
            col++;
        }
    }
}
