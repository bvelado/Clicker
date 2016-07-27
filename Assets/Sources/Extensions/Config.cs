using UnityEngine;
using System.Collections;

public enum ResourceGeneratorTemplate
{
    BaseGenerator,
    Count
}

public enum ResourceGeneratorFamily
{
    Family1,
    Family2,
    Count
}

public static class Config {

    // This should be inside of a config file
    public const float RESOURCE_CAPACITY = 999999f;
    public const int RESOURCE_PRODUCTION_FREQUENCY = 3;
    public const float RESOURCE_PRODUCTION_STEP = 20f;

    public const ResourceGeneratorTemplate BASE_GENERATOR_RESOURCE_GENERATOR_TEMPLATE= ResourceGeneratorTemplate.BaseGenerator;
    public const int BASE_GENERATOR_PRODUCTION_FREQUENCY = 5;
    public const float BASE_GENERATOR_PRODUCTION_STEP = 30f;
}
