using Zenject;

namespace PROJECT_HUSKY
{
    public class ChangeScene : Signal<ChangeScene, Scene> { } // set new scene
    public class OnChangeScene : Signal<ChangeScene, Scene> { } // scene was changed 

    public class OnTimeChanged : Signal<OnTimeChanged, int, int, int> { } // h m s
    public class OnDateChanged : Signal<OnTimeChanged, int, int, int> { } // y m d

    public class OnNewHour : Signal<OnNewHour> { } 
    public class OnCashIn : Signal<OnCashIn, int> {} //amount

    public class OnBlockSelect : Signal<OnBlockSelect, BlockController> { } //What blockController was selected

}