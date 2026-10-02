import tkinter as tk
import requests
from time import strftime

time = strftime('%H:%M:%S')
date = strftime('%m/%d/%Y')

def main():
    create_gui()

def get_weather(lat, lon):
    url = f'https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true'
    response = requests.get(url)
    data = response.json()
    if 'current_weather' in data:
        temperature = data['current_weather']['temperature']
        return temperature
    return None

def get_coordinates(city_name):
    cities_coordinates = {
    "Tokyo": {"latitude": 35.6762, "longitude": 139.6503},  # Japan
    "Delhi": {"latitude": 28.6139, "longitude": 77.2090},   # India
    "Shanghai": {"latitude": 31.2304, "longitude": 121.4737},  # China
    "Sao Paulo": {"latitude": -23.5505, "longitude": -46.6333},  # Brazil
    "Mexico City": {"latitude": 19.4326, "longitude": -99.1332},  # Mexico
    "Dhaka": {"latitude": 23.8103, "longitude": 90.4125},   # Bangladesh
    "Cairo": {"latitude": 30.0444, "longitude": 31.2357},   # Egypt
    "Mumbai": {"latitude": 19.0760, "longitude": 72.8777},  # India
    "Beijing": {"latitude": 39.9042, "longitude": 116.4074},  # China
    "Osaka": {"latitude": 34.6937, "longitude": 135.5023},  # Japan
    "Karachi": {"latitude": 24.8607, "longitude": 67.0011},  # Pakistan
    "Chongqing": {"latitude": 29.5630, "longitude": 106.5516},  # China
    "Istanbul": {"latitude": 41.0082, "longitude": 28.9784},  # Turkey
    "Buenos Aires": {"latitude": -34.6037, "longitude": -58.3816},  # Argentina
    "Kolkata": {"latitude": 22.5726, "longitude": 88.3639},  # India
}
    city_name = city_name.title()

    if city_name in cities_coordinates:
        lat = cities_coordinates[city_name]["latitude"]
        lon = cities_coordinates[city_name]["longitude"]
        return lat, lon
    else:
        return None, None
    

def create_gui():
    root = tk.Tk()
    root.title('PyWeather')

    label_city = tk.Label(root, text="City:", font=("Arial", 14))
    label_city.pack()

    entry_city = tk.Entry(root, font=("Arial", 14))
    entry_city.pack()

    button_get_weather = tk.Button(root, text="Get Weather", font=("Arial", 14), command=lambda: show_weather(entry_city, label_city, label_temp))
    button_get_weather.pack()

    label_temp = tk.Label(root, text="Temperature feel: --°C", font=("Arial", 14))
    label_temp.pack()
    label = tk.Label(root, font=('Arial', 14, 'bold'), background='black', foreground='white')
    label.pack(anchor='center')
    label.config(text=f'{date}\n{time}')

    root.mainloop()

def show_weather(entry_city, label_city, label_temp):
    city = entry_city.get()
    lat, lon = get_coordinates(city)
    temperature = get_weather(lat, lon)
    
    if city:
        label_city.config(text=f'City: {city}')
        label_temp.config(text=f'Temperature feel: {temperature}°C')
        
    else:
        label_city.config(text="We don't cover this city yet")



if __name__ == "__main__":
    main()