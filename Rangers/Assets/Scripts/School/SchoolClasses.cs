using System.Collections.Generic;

public enum SchoolClass {
	Biology, History, Maths, Writing, Geometry, Language,
	Chemistry, FLanguage, Physics, Geography, Err
}

public class SchoolClasses
{
	public const int SchoolStartTime = 7;
	public const int SchoolEndTime = 17;

	public static readonly SchoolClass[] SchoolSchedule = {
		SchoolClass.Biology, SchoolClass.History, SchoolClass.Maths,
		SchoolClass.Writing, SchoolClass.Geometry, SchoolClass.Language,
		SchoolClass.Chemistry, SchoolClass.FLanguage, SchoolClass.Physics,
		SchoolClass.Geography,
	};

	private const uint NOTALK = (1 << 0);
	private const uint NOPHON = (1 << 1);
	private const uint LSNOTE = (1 << 2);
	private const uint MRNOTE = (1 << 3);
	private static readonly Dictionary<SchoolClass, uint> ClassRules = new Dictionary<SchoolClass, uint> {
		{SchoolClass.Biology, 0x0},
		{SchoolClass.History, NOTALK},
		{SchoolClass.Maths, 0x0},
		{SchoolClass.Writing, LSNOTE},
		{SchoolClass.Geometry, NOPHON}, // Assumindo matematica
		{SchoolClass.Language, NOTALK},
		{SchoolClass.Chemistry, NOPHON | NOTALK},
		{SchoolClass.FLanguage, MRNOTE},
		{SchoolClass.Physics, NOPHON},
		{SchoolClass.Geography, 0x0},
	};

	public static bool DoesAllowPhone(SchoolClass schoolClass) => (ClassRules[schoolClass] & NOPHON) == 0u;
	public static bool DoesAllowTalk(SchoolClass schoolClass) => (ClassRules[schoolClass] & NOTALK) == 0u;
	public static bool DoesGivesNotes(SchoolClass schoolClass) => (ClassRules[schoolClass] & MRNOTE) == 1u;
	public static bool DoesTakesNotes(SchoolClass schoolClass) => (ClassRules[schoolClass] & LSNOTE) == 1u;

	public static SchoolClass GetCurrentClass() => GetCurrentClass(SchoolStartTime);

	public static SchoolClass GetCurrentClass(int hour) {
		if (hour >= SchoolStartTime && hour < 17)
			return SchoolSchedule[hour - SchoolStartTime];
		else
			return SchoolClass.Err;
	}

}

