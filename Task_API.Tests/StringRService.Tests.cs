using NUnit.Framework.Constraints;
using Task_API.Services;

namespace Task_API.Tests
{
    [TestFixture]
    public class Tests
    {
        StringRService _service;
        [SetUp]
        public void Setup()
        {
            _service = new StringRService();
        }

        [TestCase("a", "aa")]
        [TestCase("asdcx", "xcdsaasdcx")]
        public void Input_string_retunr_StringModified_Task1(string a, string b)
        {
            var expected = a;

            var actual = StringRService.StringRevers(a, 999);

            StringAssert.Contains(b, actual);
        }

        [Test]
        public void Input_aаbбcсdд_return_aбсд_Task2()
        {
            string input = "aаbбcсdд";

            string expected = "Неверрно введённые символы =  а б с д";

            var actual = StringRService.CheckStr(ref input, 999);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Input_String_Return_InfoLitersString_Task3()
        {
            string inputString = "asfd";
            //sadf
            string expected = "\nsadf\nСимвол = s, повторяется 1 раз.\nСимвол = a, повторяется 1 раз.\nСимвол = d," +
                " повторяется 1 раз.\nСимвол = f, повторяется 1 раз.";

            var actual = StringRService.StringRevers(inputString, 1);

            StringAssert.Contains(expected, actual);
        }

        /* Я совершил великое преступление, я великий грешник.
        Возможно для когото это будет опровдания, я просо объясняю.
        Можно прогнать каждое задание по одному но мне кажется проще уже полностью прогнать.Т,к у меня весь функционал
        в одной гига функции и нужно рефакторить код. */


        /*  Да я понимаю что это очень плохо делать такой тест, но свою задачу он выполняет
         В своё оправдание скажу что у меня сэссия  */
        [Test]
        public void United_test_Task_4_and_Task_5_InputString_biduin()
        {
            string inputStr = "biduin";

            string expected = "\ndibniu\nСимвол = d, повторяется 1 раз.\nСимвол = i, повторяется 2 раз.\nСимвол = b, повторяется 1 раз.\nСимвол = n, повторяется 1 раз.\nСимвол = u, повторяется 1 раз.\n\nСтрока из задания 4 = ibniu\nСтрочька из задания 5 = biinu\nСтрочька из задания 6 =";

            string actual = StringRService.StringRevers(inputStr, 1);

            StringAssert.Contains(expected, actual);
        }
    }
}