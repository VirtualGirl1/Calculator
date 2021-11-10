using System;
using AngouriMath;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace Calculator {
    class MainWindow : Window {
    
        [UI] private ListBox _Results = null;
        [UI] private TextView _Calc = null;
        [UI] private Box _Control = null;
        [UI] private Button _Settings = null;
        [UI] private RadioMenuItem _BasicView = null;
        [UI] private RadioMenuItem _AdvancedView = null;
        [UI] private RadioMenuItem _ProgramView = null;
        [UI] private RadioMenuItem _ConversionView = null;

        private TextBuffer _Buff;
        private TextTag _Size;

        // control views
        private BasicView basic;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow")) {
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;
            _ansCount = 0;
            _Super = false;
            _BasicView.Toggle();

            _Buff = new TextBuffer(new TextTagTable());
            _Size = new TextTag("Size");
            _Size.Size = 15000;
            _Buff.TagTable.Add(_Size);
            _Buff.ApplyTag(_Size, _Buff.StartIter, _Buff.EndIter);
            _Calc.Buffer = _Buff;
            _Buff.Changed += OnEdited;

            // Adds basic view
            basic = new BasicView();
            _Control.PackStart(basic, true, true, 0);

            // connect view buttons
            _BasicView.Activated += OnBasic;
            
            // basic view buttons
            basic._One.Clicked += On1Clicked;
            basic._Two.Clicked += On2Clicked;
            basic._Three.Clicked += On3Clicked;
            basic._Four.Clicked += On4Clicked;
            basic._Five.Clicked += On5Clicked;
            basic._Six.Clicked += On6Clicked;
            basic._Seven.Clicked += On7Clicked;
            basic._Eight.Clicked += On8Clicked;
            basic._Nine.Clicked += On9Clicked;
            basic._Zero.Clicked += On0Clicked;

            basic._Sqr.Clicked += OnSquare;
            basic._Root.Clicked += OnRoot;
            basic._Div.Clicked += OnDiv;
            basic._Mult.Clicked += OnMult;
            basic._Plus.Clicked += OnPlus;
            basic._Minus.Clicked += OnMinus;
            basic._Percent.Clicked += OnPercent;
            basic._Point.Clicked += OnPoint;
            basic._LPar.Clicked += OnLPar;
            basic._RPar.Clicked += OnRPar;

            basic._Clear.Clicked += OnClear;
            basic._Undo.Clicked += OnUndo;
            basic._Eql.Clicked += OnEql;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a) {
            Application.Quit();
        }

        private void OnEdited(object sender, EventArgs args) {
            _Buff.ApplyTag(_Size, _Buff.StartIter, _Buff.EndIter);

            //check the char at cursor -1
            TextIter start = _Buff.GetIterAtOffset(_Buff.CursorPosition-1);
            TextIter end = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            string c = _Buff.GetText(start, end, true);
            
            if (c == "/") {
                _Buff.Delete(ref start, ref end);
                _Buff.Insert(ref start, "÷");
            }
            else if (c == "*") {
                _Buff.Delete(ref start, ref end);
                _Buff.Insert(ref start, "×");
            }
            else if (c == "\n") {
                _Buff.Delete(ref start, ref end);
                OnEql(null, null);
            }
        }

        // View switcher buttons
        private void OnBasic(object sender, EventArgs args) {
            _Control.Remove(_Control.Children[0]);
            _Control.PackStart(basic, true, true, 0);
            
        }

        // Control buttons
        private bool _Super;
        private bool _OpenB;
        private void On1Clicked(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "1");
            _Calc.HasFocus = true;
        }

        private void On2Clicked(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "2");
            _Calc.HasFocus = true;
        }

        private void On3Clicked(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "3");
            _Calc.HasFocus = true;
        }

        private void On4Clicked(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "4");
            _Calc.HasFocus = true;
        }

        private void On5Clicked(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "5");
            _Calc.HasFocus = true;
        }

        private void On6Clicked(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "6");
            _Calc.HasFocus = true;
        }

        private void On7Clicked(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "7");
            _Calc.HasFocus = true;
        }

        private void On8Clicked(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "8");
            _Calc.HasFocus = true;
        }

        private void On9Clicked(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "9");
            _Calc.HasFocus = true;
        }

        private void On0Clicked(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "0");
            _Calc.HasFocus = true;
        }

        private void OnClear(object sender, EventArgs args) {
            TextIter start = _Buff.StartIter, end = _Buff.EndIter;
            _Buff.Delete(ref start, ref end);
            _Calc.HasFocus = true;
        }

        private void OnUndo(object sender, EventArgs args) {
            TextIter ittr = _Buff.GetIterAtLineOffset(0, _Buff.CursorPosition);
            _Buff.Backspace(ref ittr, true, true);
            _Calc.HasFocus = true;
        }
        private void OnPoint(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, ".");
            _Calc.HasFocus = true;
        }

        private void OnPercent(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "%");
            _Calc.HasFocus = true;
        }

        private void OnPlus(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "+");
            _Calc.HasFocus = true;
        }

        private void OnMinus(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "-");
            _Calc.HasFocus = true;
        }

        private void OnDiv(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "÷");
            _Calc.HasFocus = true;
        }

        private void OnMult(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "×");
            _Calc.HasFocus = true;
        }

        private void OnLPar(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "(");
            _Calc.HasFocus = true;
        }

        private void OnRPar(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, ")");
            _Calc.HasFocus = true;
        }
        private void OnSquare(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "²");
            _Calc.HasFocus = true;
        }
        
        private void OnRoot(object sender, EventArgs args) {
            var ittr = _Buff.GetIterAtOffset(_Buff.CursorPosition);
            _Buff.Insert(ref ittr, "√");
            
            _Calc.HasFocus = true;
        }

        private int _ansCount;
        private void OnEql(object sender, EventArgs args) {

            if (_ansCount == 3) {
                var rem = _Results.GetRowAtIndex(0);
                _Results.Remove(rem);
                _ansCount--;
            }

            string text = cleanExpr();
            Entity expr = text;
            var res = expr.EvalNumerical().ToString();

            var label = new Label();
            label.UseMarkup = true;
            label.Markup = "<span size=\"x-large\">" + _Buff.Text + "</span> =\t\t" + 
            "<span size=\"xx-large\">" + res + "</span>";
            label.Xalign = 0;
            
            _Results.Insert(label, -1);
            _Results.ShowAll();
            _ansCount++;
            
            // Clear the buffer
            var start = _Buff.StartIter;
            var end = _Buff.EndIter;
            _Buff.Delete(ref start, ref end);
            
            _Calc.HasFocus = true;
        }

        // parse the buffer and clean it up for datatable
        private string cleanExpr() {
            string text = _Buff.GetText(_Buff.StartIter, _Buff.EndIter, true);
            string clean = "";

            // replace obscure characters with ones that datatable will understand
            bool openb = false;
            for (int i = 0; i < text.Length; i++) {
                
                char c = text[i];
                if (c == '÷') {
                    clean += '/';
                }
                else if (c == '×') {
                    clean += '*';
                }
                else if (c == '²') {
                    clean += "^2";
                }
                else if (c == '√'){
                    clean += "sqrt(";
                    openb = true;
                }

                else {
                    clean += c;
                }
                
            }
            // if left bracket was never closed, close it
            if (openb == true) {
                clean += ")";
            }

            return clean;
        }
    }
}
