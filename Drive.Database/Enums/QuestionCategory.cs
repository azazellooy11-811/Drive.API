using System.ComponentModel;

namespace Drive.Database.Enums
{
    public enum QuestionCategory
    {
        [Description("Общие положения")] GeneralProvisions,
        [Description("Дорожные знаки")] RoadSigns,
        [Description("Дорожная разметка")] RoadMarkings,

        [Description("Сигналы светофора и регулировщика")]
        TrafficLightsAndTrafficController,
        [Description("Скорость движения")] TravelSpeed,

        [Description("Начало движения, маневрирование")]
        StartOfMovementManeuvering,

        [Description("Обгон, опережение, встречный разъезд")]
        OvertakingAdvancingOncomingTraffic,
        [Description("Остановка и стоянка")] StopAndParking,
        [Description("Проезд перекрестков")] Crossings,

        [Description("Пользование внешними световыми приборами и звуковыми сигналами")]
        UseOfExternalLightsAndSoundSignals,

        [Description("Неисправности и условия допуска транспортных средств к эксплуатации")]
        MalfunctionsAndConditionsForTheAdmissionOfVehiclesToOperation,

        [Description("Безопасность движения и техника управления автомобилем")]
        TrafficSafetyAndDrivingTechnique,

        [Description("Оказание доврачебной медицинской помощи")]
        ProvidingFirstAid,

        [Description("Общие обязанности водителей")]
        GeneralDutiesOfDrivers,

        [Description("Расположение транспортных средств на проезжей части")]
        LocationOfVehiclesOnTheRoadway,

        [Description("Приоритет маршрутных транспортных средств")]
        ShuttleVehiclePriority,

        [Description("Буксировка механических транспортных средств")]
        TowingOfMotorVehicles,

        [Description("Применение специальных сигналов")]
        ApplicationOfSpecialSignals,

        [Description("Движение по автомагистралям")]
        MotorwayTraffic,

        [Description("Учебная езда и дополнительные требования к движению велосипедистов")]
        TrainingRideAndAdditionalTrafficRequirementsForCyclists,

        [Description("Движение в жилых зонах")]
        TrafficInResidentialAreas,

        [Description("Движение через железнодорожные пути")]
        TrafficAcrossRailroadTracks,

        [Description("Пешеходные переходы и места остановок маршрутных транспортных средств")]
        PedestrianCrossingsAndStoppingPlacesOfRouteVehicles,

        [Description("Перевозка людей и грузов")]
        TransportationOfPeopleAndGoods,

        [Description("Ответственность водителя")]
        DriverResponsibility,

        [Description("Применение аварийной сигнализации и знака аварийной остановки")]
        ApplicationOfHazardWarningAndWarningTriangle
    }
}