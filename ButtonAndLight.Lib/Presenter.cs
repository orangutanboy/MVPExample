using Microsoft.SPOT;

namespace ButtonAndLight.Lib
{
    public class Presenter
    {
        IView _view;
        Model _model;

        public Presenter(IView view, Model model)
        {
            _view = view;
            _model = model;

            _view.ButtonPressed += new ButtonPressedEventHandler(view_ButtonPressed);
            _model.ColourChanged += new Model.ColourChangedEventHandler(model_ColourChanged);
        }

        void model_ColourChanged(object sender, ColourChangedEventArgs args)
        {
            _view.ShowColour(args.R, args.G, args.B);
        }

        void view_ButtonPressed(object sender, EventArgs args)
        {
            _model.CalculateNewColour();
        }
    }
}
