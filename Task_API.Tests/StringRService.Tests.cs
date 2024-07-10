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
        public void Input_a�b�c�d�_return_a���_Task2()
        {
            string input = "a�b�c�d�";

            string expected = "�������� �������� ������� =  � � � �";

            var actual = StringRService.CheckStr(ref input, 999);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Input_String_Return_InfoLitersString_Task3()
        {
            string inputString = "asfd";
            //sadf
            string expected = "\nsadf\n������ = s, ����������� 1 ���.\n������ = a, ����������� 1 ���.\n������ = d," +
                " ����������� 1 ���.\n������ = f, ����������� 1 ���.";

            var actual = StringRService.StringRevers(inputString, 1);

            StringAssert.Contains(expected, actual);
        }

        /* � �������� ������� ������������, � ������� �������.
        �������� ��� ������ ��� ����� ����������, � ����� ��������.
        ����� �������� ������ ������� �� ������ �� ��� ������� ����� ��� ��������� ��������.�,� � ���� ���� ����������
        � ����� ���� ������� � ����� ����������� ���. */


        /*  �� � ������� ��� ��� ����� ����� ������ ����� ����, �� ���� ������ �� ���������
         � ��� ���������� ����� ��� � ���� ������  */
        [Test]
        public void United_test_Task_4_and_Task_5_InputString_biduin()
        {
            string inputStr = "biduin";

            string expected = "\ndibniu\n������ = d, ����������� 1 ���.\n������ = i, ����������� 2 ���.\n������ = b, ����������� 1 ���.\n������ = n, ����������� 1 ���.\n������ = u, ����������� 1 ���.\n\n������ �� ������� 4 = ibniu\n�������� �� ������� 5 = biinu\n�������� �� ������� 6 =";

            string actual = StringRService.StringRevers(inputStr, 1);

            StringAssert.Contains(expected, actual);
        }
    }
}