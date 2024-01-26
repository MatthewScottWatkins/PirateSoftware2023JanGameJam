using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    [SerializeField] private Station[] stations;

    public int GetStationCount() { return stations.Length; }

    public Station GetRandomStation() 
    {
        List<Station> availableStations = new List<Station>();
        foreach(Station station in stations)
        {
            if(!station.GetMessyBool() && !station.GetClaimedBool())
            {
                availableStations.Add(station);
            }
        }
        if(availableStations.Count <= 1)
        {
            return availableStations[0];
        }
        return availableStations[Random.Range(0, availableStations.Count)];
    }

    public Station GetRandomStationExcluding(Station excludedStation)
    {
        List<Station> availableStations = new List<Station>();
        foreach (Station station in stations)
        {
            if (!station.GetMessyBool() && !station.GetClaimedBool())
            {
                availableStations.Add(station);
            }
        }

        Station targetStation = availableStations[Random.Range(0, availableStations.Count)];
        int attemptCount = 0;

        while (targetStation != excludedStation)
        {
            targetStation = availableStations[Random.Range(0, availableStations.Count)];

            if (attemptCount >= 15)
                break;
        }

        return targetStation;
    }
}
