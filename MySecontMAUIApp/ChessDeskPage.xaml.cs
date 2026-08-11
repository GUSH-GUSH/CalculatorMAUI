namespace MySecondMAUIApp;

public partial class ChessDeskPage : ContentPage
{

    public static readonly (Color Dark, Color Light) ChessFieldsColors = (
                                                    Dark: Color.FromRgb(171, 105, 54),
                                                    Light: Color.FromRgb(222, 190, 145));
    
    public ChessDeskPage()
	{
		InitializeComponent();
        InitializeChessDesk();
    }

	private void InitializeChessDesk() {
        InitializeChessFields();
    }

	private void InitializeChessFields()
    {
        for (int row = 0; row < ChessGrid.RowDefinitions.Count; row++)
        {
            for (int col = 0; col < ChessGrid.ColumnDefinitions.Count; col++)
            {
                BoxView boxView = new BoxView
                {
                    Color = (row + col) % 2 != 0 ? ChessFieldsColors.Dark : ChessFieldsColors.Light
                };

                ChessGrid.Add(boxView, col, row);
            }
        }
    }
}