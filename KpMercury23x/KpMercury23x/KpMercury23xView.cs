using Scada.Comm.Devices.KpMercury23x;
using Scada.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scada.Comm.Devices
{
    public sealed class KpMercury23xView : KPView
    {


        public override string KPDescr
        {
            get
            {
                return 
                "Автор Бурахин Андрей, email: aburakhin@bk.ru\n\n" +
                "Опрос электросчётчика Меркурий (230, 231, 232, 233, 236).\n\n" +
                "Адрес счетчика  = Администратор -> КП -> Адрес\n\n" +

                "Командная строка Коммуникатора, параметр должен заканчиваться разделителем ;\n" +
                "1-й параметр = Пароль счетчика 6 цифр\n2-й параметр = Уровень доступа 1 или 2\n" +
                "3-й параметр = битовая маска считываемых параметров\n" +
                "бит числа, выставленный в 1 разрешает чтение группы параметров\n\n" +
                "    Мгновенные значения:\n\n" +
                "bit 0 - Мощность P ∑, L1, L2, L3\n" +
                "bit 1 - Мощность Q ∑, L1, L2, L3\n" +
                "bit 2 - Мощность S ∑, L1, L2, L3\n" +
                "bit 3 - Cos f ∑, L1, L2, L3\n" +
                "bit 4 - Напряжение L1, L2, L3\n" +
                "bit 5 - Ток L1, L2, L3\n" +
                "bit 6 - Угол м-ду ф. L1-L2, L1-L3, L2-L3\n" +
                "bit 7 - Частота сети\n\n" +
                "    Энергия от сброса:\n\n" +
                "bit 8  - Энергия ∑ А+, А-, R+, R-\n" +
                "bit 9  - Тариф 1   А+, А-, R+, R-\n" +
                "bit 10 - Тариф 2   А+, А-, R+, R-\n" +
                "bit 11 - Тариф 3   А+, А-, R+, R-\n" +
                "bit 12 - Тариф 4   А+, А-, R+, R-\n" +
                "bit 13 - Энергия ∑ А+ L1, L2, L3\n" +
                "bit 14 - Тариф 1   А+ L1, L2, L3\n" +
                "bit 15 - Тариф 2   А+ L1, L2, L3\n" +
                "bit 16 - Тариф 3   А+ L1, L2, L3\n" +
                "bit 16 - Тариф 4   А+ L1, L2, L3\n\n" +
                "Пример: 255 - все значения мгновенных мощностей\n" +
                "191 - значения мгновенных мощностей без углов м-ду ф.\n" +
                "261888 - все значения энергии от сброса\n" +
                "59136  - значения энергии от сброса без тарифов 3 и 4\n\n" +
                "Пример командной строки - 111111;1;191; - пароль 111111, уровень доступа 1, читать\n" +
                "значения мгновенных значений без углов между фазами\n" +
                ";;191 = пароль по умолчанию 111111, уровень доступа по умолчанию 1\n" +
                "Пустая строка пароль по умолчанию 111111, уровень доступа 1, все параметры 262143";
            }
        }

        public KpMercury23xView() : this(0)
        {
        }

        public KpMercury23xView(int number) : base(number)
        {
            CanShowProps = true;
        }


        // Получить параметры опроса КП по умолчанию
        public override KPReqParams DefaultReqParams
        {
            get
            {
                return new KPReqParams() { Timeout = 1000, Delay = 200 };
            }
        }


        // Отобразить свойства КП
        public override void ShowProps()
        {
            FormSetting.ShowDialog(Number, KPProps, AppDirs); // отображение фармы параметров
        }
    }
}
