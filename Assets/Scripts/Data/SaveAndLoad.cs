using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveAndLoad
{
    private static readonly string PLAYER_FILENAME = Application.persistentDataPath + "/playerINFO.dat";
    private static readonly string MAPS_FILENAME = Application.persistentDataPath + "/mapsStats.dat";
    private static readonly string CARS_FILENAME = Application.persistentDataPath + "/cars.dat";
    private static readonly string [] carsCollection = new string [2] { "car1", "car2" };

    public static void unmuteMusic()
    {
        if (File.Exists(PLAYER_FILENAME))
        {
            Player data = getPlayerData();
            data.Music = true;
            SaveGamePlayer(data);
        }
        else
        {
            SaveGamePlayer();
            unmuteMusic();
        }

    }
    public static void muteMusic()
    {
        if (File.Exists(PLAYER_FILENAME))
        {
            Player data = getPlayerData();
            data.Music = false;
            SaveGamePlayer(data);
        }
        else
        {
            SaveGamePlayer();
            muteMusic();
        }

    }
    public static bool isMusic()
    {
        if (File.Exists(PLAYER_FILENAME))
        {
            return getPlayerData().Music;
        }
        else
        {
            SaveGamePlayer();
            return isMusic();
        }
    }
    public static void unmuteSound()
    {
        if (File.Exists(PLAYER_FILENAME))
        {
            Player data = getPlayerData();
            data.Sound = true;
            SaveGamePlayer(data);
        }
        else
        {
            SaveGamePlayer();
            unmuteSound();
        }

    }
    public static void muteSound()
    {
        if (File.Exists(PLAYER_FILENAME))
        {
            Player data = getPlayerData();
            data.Sound = false;
            SaveGamePlayer(data);
        }
        else
        {
            SaveGamePlayer();
            muteSound();
        }

    }
    public static bool isSound()
    {
        if (File.Exists(PLAYER_FILENAME))
        {
            return getPlayerData().Sound;
        }
        else
        {
            SaveGamePlayer();
            return isSound();
        }
    }
    public static int getCoinsAmount()
    {
        if (File.Exists(PLAYER_FILENAME))
        {
            return getPlayerData().CoinsAmount;           
        }
        else
        {        
            SaveGamePlayer();
            return getCoinsAmount();
        }     
    }
    public static void increaseCoinsAmount(int value)
    {
        if(value > 0)
        {
            if (File.Exists(PLAYER_FILENAME))
            {
                Player data = getPlayerData();
                data.CoinsAmount += value;
                SaveGamePlayer(data);
            }
            else
            {
                SaveGamePlayer();
                increaseCoinsAmount(value);
            }
        }      
    }
    public static void decreaseCoinsAmount(int value)
    {
        if (value > 0 && getCoinsAmount() - value >= 0)
        {
            if (File.Exists(PLAYER_FILENAME))
            {
                Player data = getPlayerData();
                data.CoinsAmount -= value;
                SaveGamePlayer(data);
            }
            else
            {
                SaveGamePlayer();
                decreaseCoinsAmount(value);
            }
        }
    }
    public static int getGemsAmount()
    {
        if (File.Exists(PLAYER_FILENAME))
        {
            return getPlayerData().GemsAmount;
        }
        else
        {
            SaveGamePlayer();
            return getGemsAmount();
        }
    }
    public static void increaseGemsAmount(int value)
    {
        if (value > 0)
        {
            if (File.Exists(PLAYER_FILENAME))
            {
                Player data = getPlayerData();
                data.GemsAmount += value;
                SaveGamePlayer(data);
            }
            else
            {
                SaveGamePlayer();
                increaseGemsAmount(value);
            }
        }
    }
    public static void decreaseGemsAmount(int value)
    {
        if (value > 0 && getGemsAmount() - value >= 0)
        {
            if (File.Exists(PLAYER_FILENAME))
            {
                Player data = getPlayerData();
                data.GemsAmount -= value;
                SaveGamePlayer(data);
            }
            else
            {
                SaveGamePlayer();
                decreaseGemsAmount(value);
            }
        }
    }
    public static string getSelectedCar()
    {
        if (File.Exists(PLAYER_FILENAME))
        {
            return getPlayerData().SelectedCar;
        }
        else
        {
            SaveGamePlayer();
            return getSelectedCar();
        }
    }
    public static void setSelectedCar(string carName)
    {
        if (File.Exists(PLAYER_FILENAME))
        {
           Player data = getPlayerData();
           data.SelectedCar = carName;
           SaveGamePlayer(data);
        }
        else
        {
           SaveGamePlayer();
           setSelectedCar(carName);
        }
        
    }
    private static void SaveGamePlayer()
    {
        FileStream saveFile = null;
        try
        {
            BinaryFormatter binaryConverter = new BinaryFormatter();
            saveFile = new FileStream(PLAYER_FILENAME, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            //saveFile = File.Create(Application.persistentDataPath + PLAYER_FILENAME);
            binaryConverter.Serialize(saveFile, new Player());
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if(saveFile != null)
            {
                saveFile.Close();
            }
        }
    }
    private static void SaveGamePlayer(Player player)
    {
        FileStream saveFile = null;
        try
        {
            BinaryFormatter binaryConverter = new BinaryFormatter();
            saveFile = new FileStream(PLAYER_FILENAME, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            //saveFile = File.Create(Application.persistentDataPath + PLAYER_FILENAME);
            binaryConverter.Serialize(saveFile, player);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if (saveFile != null)
            {
                saveFile.Close();
            }
        }
    }
    private static Player getPlayerData()
    {
        FileStream saveFile = null;
        Player GameData = null;
        try
        {
            BinaryFormatter binaryConverter = new BinaryFormatter();
            saveFile = new FileStream(PLAYER_FILENAME, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            //saveFile = File.Open(Application.persistentDataPath + PLAYER_FILENAME, FileMode.Open);
            GameData = binaryConverter.Deserialize(saveFile) as Player;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if (saveFile != null)
            {
                saveFile.Close();
            }
        }

        return GameData;
    }

    public static float getMap(int map, int level)
    {
        if (File.Exists(MAPS_FILENAME))
        {
            return getMapData().getMapAtIndex(map, level);
        }
        else
        {
            SaveGameMap();
            return getMap(map, level);
        }
    }
    public static void setMap(int map, int level, float time)
    {
        if (File.Exists(MAPS_FILENAME))
        {
            Map myMap = getMapData();
            myMap.setMapAtIndex(map, level, time);
            SaveGameMap(myMap);
        }
        else
        {
            SaveGameMap();
            setMap(map, level, time);
        }
    }
    private static void SaveGameMap()
    {
        BinaryFormatter binaryConverter = new BinaryFormatter();
        FileStream saveFile = new FileStream(MAPS_FILENAME, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        binaryConverter.Serialize(saveFile, new Map());
        saveFile.Close();
    }
    private static void SaveGameMap(Map map)
    {
        BinaryFormatter binaryConverter = new BinaryFormatter();
        FileStream saveFile = new FileStream(MAPS_FILENAME, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        binaryConverter.Serialize(saveFile, map);
        saveFile.Close();
    }
    private static Map getMapData()
    {
        BinaryFormatter binaryConverter = new BinaryFormatter();
        FileStream saveFile = new FileStream(MAPS_FILENAME, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        Map GameData = binaryConverter.Deserialize(saveFile) as Map;
        saveFile.Close();

        return GameData;
    }

    public static int getCurrVehicleGrip(string name)
    {
        if (File.Exists(CARS_FILENAME))
        {
            List<Car> cars = getCars();
            foreach(Car car in cars)
            {
                if (car.getCarName().Equals(name))
                {
                    return car.getVehicleGrip();
                }
            }
            return 0;
        }
        else
        {
            SaveCars();
            return getCurrVehicleGrip(name);
        }
    }
    public static int getCurrSpeed(string name)
    {
        if (File.Exists(CARS_FILENAME))
        {
            List<Car> cars = getCars();
            foreach (Car car in cars)
            {
                if (car.getCarName().Equals(name))
                {
                    return car.getSpeed();
                }
            }
            return 0;
        }
        else
        {
            SaveCars();
            return getCurrSpeed(name);
        }
    }
    public static int getCurrAcceleration(string name)
    {
        if (File.Exists(CARS_FILENAME))
        {
            List<Car> cars = getCars();
            foreach (Car car in cars)
            {
                if (car.getCarName().Equals(name))
                {
                    return car.getAcceleration();
                }
            }
            return 0;
        }
        else
        {
            SaveCars();
            return getCurrAcceleration(name);
        }
    }
    public static int getCurrTurbo(string name)
    {
        if (File.Exists(CARS_FILENAME))
        {
            List<Car> cars = getCars();
            foreach (Car car in cars)
            {
                if (car.getCarName().Equals(name))
                {
                    return car.getTurbo();
                }
            }
            return 0;
        }
        else
        {
            SaveCars();
            return getCurrTurbo(name);
        }
    }
    public static void increaseCurrVehicleGrip(string name)
    {
        if (File.Exists(CARS_FILENAME))
        {
            List<Car> cars = getCars();
            foreach (Car car in cars)
            {
                if (car.getCarName().Equals(name))
                {
                    car.increaseVehicleGrip();
                    SaveCars(cars);
                    return;
                }
            }
        }
        else
        {
            SaveCars();
            getCurrVehicleGrip(name);
        }
    }
    public static void increaseSpeed(string name)
    {
        if (File.Exists(CARS_FILENAME))
        {
            List<Car> cars = getCars();
            foreach (Car car in cars)
            {
                if (car.getCarName().Equals(name))
                {
                    car.increaseSpeed();
                    SaveCars(cars);
                    return;
                }
            }
        }
        else
        {
            SaveCars();
            increaseSpeed(name);
        }
    }
    public static void increaseAcceleration(string name)
    {
        if (File.Exists(CARS_FILENAME))
        {
            List<Car> cars = getCars();
            foreach (Car car in cars)
            {
                if (car.getCarName().Equals(name))
                {
                    car.increaseAcceleration();
                    SaveCars(cars);
                    return;
                }
            }
        }
        else
        {
            SaveCars();
            increaseAcceleration(name);
        }
    }
    public static void increaseTurbo(string name)
    {
        if (File.Exists(CARS_FILENAME))
        {
            List<Car> cars = getCars();
            foreach (Car car in cars)
            {
                if (car.getCarName().Equals(name))
                {
                    car.increaseTurbo();
                    SaveCars(cars);
                    return;
                }
            }
        }
        else
        {
            SaveCars();
            increaseTurbo(name);
        }
    }
    public static int getSelectedSkin(string name)
    {
        if (File.Exists(CARS_FILENAME))
        {
            List<Car> cars = getCars();
            return cars.Find(x => x.getCarName().Equals(name)).SelectedSkin;
        }
        else
        {
            SaveCars();
            return getSelectedSkin(name);
        }
    }

    public static void setSelectedSkin(string name, int index)
    {
        if (File.Exists(CARS_FILENAME))
        {
            List<Car> cars = getCars();
            Car car = cars.Find(x => x.getCarName().Equals(name));
            car.SelectedSkin = index;
            SaveCars(cars);
            return;
        }
        else
        {
            SaveCars();
            setSelectedSkin(name, index);
        }
    }
    private static void SaveCars()
    {
        BinaryFormatter binaryConverter = new BinaryFormatter();
        FileStream saveFile = new FileStream(CARS_FILENAME, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        List<Car> myCars = checkCarsAmount(null);
        binaryConverter.Serialize(saveFile, myCars);
        saveFile.Close();
    }
    private static void SaveCars(List<Car> cars)
    {
        BinaryFormatter binaryConverter = new BinaryFormatter();
        FileStream saveFile = new FileStream(CARS_FILENAME, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        cars = checkCarsAmount(cars);
        binaryConverter.Serialize(saveFile, cars);
        saveFile.Close();
    }
    private static List<Car> getCars()
    {
        BinaryFormatter binaryConverter = new BinaryFormatter();
        FileStream saveFile = new FileStream(CARS_FILENAME, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        List<Car> GameData = binaryConverter.Deserialize(saveFile) as List<Car>;
        GameData = checkCarsAmount(GameData);
        saveFile.Close();

        return GameData;
    }
    private static List<Car> checkCarsAmount(List<Car> cars)
    {
        if(cars == null)
        {
            cars = new List<Car>();
        }
        while(cars.Count < carsCollection.Length)
        {
            for(int i = 0; i < carsCollection.Length; i++)
            {
                bool carInCollection = false;
                foreach(Car car in cars)
                {
                    if (car.getCarName().Equals(carsCollection[i]))
                    {
                        carInCollection = true;
                        break;
                    }
                }
                if (!carInCollection)
                {
                    cars.Add(new Car(carsCollection[i]));
                    break;
                }
            }
        }

        return cars;
    }

}
