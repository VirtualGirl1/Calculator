using Gtk;

namespace Calculator {

    public class BasicView : VBox { // would use grid but there's no docs

        // Buttons
        // There are A LOT OF BUTTONS
        public Button _Zero;
        public Button _One;
        public Button _Two;
        public Button _Three;
        public Button _Four;
        public Button _Five;
        public Button _Six;
        public Button _Seven;
        public Button _Eight;
        public Button _Nine;

        public Button _Point;
        public Button _Percent;
        public Button _Plus;
        public Button _Minus;
        public Button _Mult;
        public Button _Div;
        public Button _Undo;
        public Button _Clear;
        public Button _LPar;
        public Button _RPar;
        public Button _Sqr;
        public Button _Root;
        public Button _Eql;

        public BasicView() {
            HBox b0 = new HBox();
            HBox b1 = new HBox();
            HBox b2 = new HBox();
            HBox b3 = new HBox();

            this.PackStart(b0, true, true, 5);
            this.PackStart(b1, true, true, 5);
            this.PackStart(b2, true, true, 5);
            this.PackStart(b3, true, true, 5);

            // Pack grid
            // row 1
            _Seven = new Button();
            _Seven.Label = "7";
            b0.PackStart(_Seven, true, true, 5);
            
            _Eight = new Button();
            _Eight.Label = "8";
            b0.PackStart(_Eight, true, true, 5);

            _Nine = new Button();
            _Nine.Label = "9";
            b0.PackStart(_Nine, true, true, 5);
            
            _Div = new Button();
            _Div.Label = "÷";
            b0.PackStart(_Div, true, true, 5);

            Image undoIcon = new Image();
            undoIcon.SetFromIconName("edit-undo-symbolic", IconSize.Button);
            _Undo = new Button(undoIcon);
            b0.PackStart(_Undo, true, true, 5);

            _Clear = new Button();
            _Clear.Label = "C";
            b0.PackStart(_Clear, true, true, 5);

            // row 2
            _Four = new Button();
            _Four.Label = "4";
            b1.PackStart(_Four, true, true, 5);

            _Five = new Button();
            _Five.Label = "5";
            b1.PackStart(_Five, true, true, 5);

            _Six = new Button();
            _Six.Label = "6";
            b1.PackStart(_Six, true, true, 5);

            _Mult = new Button();
            _Mult.Label = "×";
            b1.PackStart(_Mult, true, true, 5);

            _LPar = new Button();
            _LPar.Label = "(";
            b1.PackStart(_LPar, true, true, 5);

            _RPar = new Button();
            _RPar.Label = ")";
            b1.PackStart(_RPar, true, true, 5);

            // row 3
            _One = new Button();
            _One.Label = "1";
            b2.PackStart(_One, true, true, 5);

            _Two = new Button();
            _Two.Label = "2";
            b2.PackStart(_Two, true, true, 5);

            _Three = new Button();
            _Three.Label = "3";
            b2.PackStart(_Three, true, true, 5);

            _Minus = new Button();
            _Minus.Label = "-";
            b2.PackStart(_Minus, true, true, 5);

            Label SqrLabel = new Label();
            SqrLabel.LabelProp = "x<sup>2</sup>";
            SqrLabel.UseMarkup = true;
            _Sqr = new Button(SqrLabel);
            b2.PackStart(_Sqr, true, true, 5);

            _Root = new Button();
            _Root.Label = "√";
            b2.PackStart(_Root, true, true, 5);

            // Row 3
            _Zero = new Button();
            _Zero.Label = "0";
            b3.PackStart(_Zero, true, true, 5);

            _Point = new Button();
            _Point.Label = ".";
            b3.PackStart(_Point, true, true, 5);

            _Percent = new Button();
            _Percent.Label = "%";
            b3.PackStart(_Percent, true, true, 5);

            _Plus = new Button();
            _Plus.Label = "+";
            b3.PackStart(_Plus, true, true, 5);

            _Eql = new Button();
            _Eql.Label = "=";
            b3.PackStart(_Eql, true, true, 5);

            
            this.ShowAll();
        }
    }
}