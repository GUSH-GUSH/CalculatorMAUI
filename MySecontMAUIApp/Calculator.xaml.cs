using System.Text;
namespace MySecondMAUIApp;

public partial class Calculator : ContentPage
{
	double firstNumber;
	double secondNumber;
    Operation currentOperation = Operation.EMPTY;

    enum Operation { ADD, SUBTRACT, MULTIPLY, DIVIDE, EMPTY};

	Dictionary<Operation, string> operationsStrings = new Dictionary<Operation, string>()
	{
		{ Operation.ADD, "+" },
		{ Operation.SUBTRACT, "-" },
		{ Operation.MULTIPLY, "*" },
		{ Operation.DIVIDE, "/" }
	};

    public double CurrentNumber
    {
        get
        {
            if (double.TryParse(InputView.Text, out double number)) return number;
            return 0;
        }
    }

    public Calculator()
	{
		InitializeComponent();
		ResetCalculator();
	}

    #region --- EVENTS HANDLERS ---

    private void ButtonClicked(object sender, EventArgs args) {
		Button? button = sender as Button;
		if (button == null) return;

		if (char.IsDigit(button.Text[0]))
		{
			PrintToInputView(button.Text);
		}
		else {
            //TODO: Добавить возможность ввода отрицательных чисел + вызов функции "Равно" перед каждым действием, если в InputView есть число и текущая операция не пустая
            switch (button.Text) {
                case "C":
                    ResetCalculator();
                    break;
				case "<=":
                    RemoveLastCharacterFromInputView();
					if (currentOperation == Operation.EMPTY) ClearActionView();		
					break;
				case "+":
                        if (currentOperation != Operation.EMPTY)
                        {
                            ActionView.Text = $"{firstNumber} + ";
                            currentOperation = Operation.ADD;
                            break;
                        }
                    double currentNumber = CurrentNumber;
                    if (currentOperation != Operation.EMPTY) CalculateResult();
                    else firstNumber = currentNumber;
                    ActionView.Text = $"{firstNumber} + ";
					currentOperation = Operation.ADD;
                    ClearInputView();
					break;
				case "-":
                    if (string.IsNullOrEmpty(InputView.Text))
                    {
                        if (currentOperation != Operation.EMPTY)
                        {
                            ActionView.Text = $"{firstNumber} - ";
                            currentOperation = Operation.SUBTRACT;
                        } else PrintToInputView("-");
                        break;
                    }
                    currentNumber = CurrentNumber;
                    if (currentOperation != Operation.EMPTY) CalculateResult();
                    else firstNumber = currentNumber;
                    ActionView.Text = $"{firstNumber} - ";
					currentOperation = Operation.SUBTRACT;
                    ClearInputView();
					break;
				case "/":
                    if (currentOperation != Operation.EMPTY) {
                        ActionView.Text = $"{firstNumber} / ";
                        currentOperation = Operation.DIVIDE;
                        break;
                    }
                    currentNumber = CurrentNumber;
                    if (currentOperation != Operation.EMPTY) CalculateResult();
                    else firstNumber = currentNumber;
					ActionView.Text = $"{firstNumber} / ";
                    currentOperation = Operation.DIVIDE;
                    ClearInputView();
					break;
				case "*":
                    if (currentOperation != Operation.EMPTY)
                    {
                        ActionView.Text = $"{firstNumber} * ";
                        currentOperation = Operation.MULTIPLY;
                        break;
                    }
                    currentNumber = CurrentNumber;
                    if (currentOperation != Operation.EMPTY) CalculateResult();
                    else firstNumber = currentNumber;
					ActionView.Text = $"{firstNumber} * ";
                    currentOperation = Operation.MULTIPLY;
                    ClearInputView();
					break;
                case "=":
                    CalculateResult();
                    break;
            }
		}
	}

    #endregion

    private void CalculateResult()
    {
        if (currentOperation == Operation.EMPTY || string.IsNullOrEmpty(InputView.Text)) return;
        
        this.secondNumber = double.Parse(InputView.Text);
        ActionView.Text = $"{firstNumber} {operationsStrings[currentOperation]} {secondNumber} =";

        switch (currentOperation)
        {
            case Operation.ADD: firstNumber += secondNumber; break;
            case Operation.SUBTRACT: firstNumber -= secondNumber; break;
            case Operation.MULTIPLY: firstNumber *= secondNumber; break;
            case Operation.DIVIDE: firstNumber /= secondNumber; break;
        }

        ClearInputView();
        PrintToInputView(firstNumber.ToString());
        currentOperation = Operation.EMPTY;
    }

    private void ResetCalculator()
    {
        firstNumber = 0;
        secondNumber = 0;
        ClearViews();
    }

    #region --- Input View Manipulation ---

    private void PrintToInputView(string value) => InputView.Text += value;
	private void RemoveLastCharacterFromInputView()
    {
        if (string.IsNullOrEmpty(InputView.Text)) return;
		if (double.TryParse(InputView.Text, out double number))
		{
			if(double.IsNaN(number) || double.IsInfinity(number) || number < 0 && InputView.Text.Length == 2) ClearInputView();
			else InputView.Text = InputView.Text.Substring(0, InputView.Text.Length - 1);
		}
		else ClearInputView();
    }
    private void ClearInputView() => InputView.Text = string.Empty;
    private void ClearActionView() => ActionView.Text = string.Empty;
	private void ClearViews()
    {
        ClearInputView();
        ClearActionView();
    }

    #endregion --- Input View Manipulation ---

}