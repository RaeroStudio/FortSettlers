# Инструкция по настройке UI в Unity

## 1. Создание базовой структуры UI

1. Создайте новый Canvas:
   - GameObject -> UI -> Canvas
   - Настройте Canvas Scaler:
     - UI Scale Mode: Scale With Screen Size
     - Reference Resolution: 1920 x 1080
     - Screen Match Mode: Match Width Or Height
     - Match: 0.5

2. Создайте EventSystem:
   - GameObject -> UI -> Event System

## 2. Настройка главного меню

1. Создайте панель главного меню:
   - GameObject -> UI -> Panel
   - Назовите "MainMenuPanel"
   - Добавьте компонент MainMenuButtons

2. Создайте кнопки:
   - GameObject -> UI -> Button
   - Создайте три кнопки: "PlayButton", "SettingsButton", "ExitButton"
   - Настройте текст на кнопках
   - Добавьте анимации наведения

3. Настройте MainMenuButtons:
   - Перетащите кнопки в соответствующие поля
   - Добавьте AudioSource и звук клика

## 3. Настройка панели настроек

1. Создайте панель настроек:
   - GameObject -> UI -> Panel
   - Назовите "SettingsPanel"
   - Добавьте компонент SettingsManager

2. Создайте слайдеры:
   - GameObject -> UI -> Slider
   - Создайте два слайдера: "MusicVolumeSlider", "SoundVolumeSlider"
   - Настройте минимальное (0) и максимальное (1) значения

3. Создайте кнопку возврата:
   - GameObject -> UI -> Button
   - Назовите "BackButton"

4. Настройте SettingsManager:
   - Перетащите слайдеры и кнопку в соответствующие поля
   - Создайте AudioMixer и настройте группы
   - Добавьте AudioSource

## 4. Настройка HUD

1. Создайте панель HUD:
   - GameObject -> UI -> Panel
   - Назовите "HUDPanel"
   - Добавьте компонент HUDManager

2. Создайте текстовые поля:
   - GameObject -> UI -> Text - TextMeshPro
   - Создайте три текстовых поля для ресурсов, времени и поселенцев
   - Настройте шрифт и размер

3. Настройте HUDManager:
   - Перетащите текстовые поля в соответствующие поля

## 5. Настройка UIManager

1. Создайте пустой GameObject:
   - Назовите "UIManager"
   - Добавьте компонент UIManager

2. Настройте UIManager:
   - Перетащите Canvas в поле mainCanvas
   - Перетащите панели в соответствующие поля

## 6. Тестирование

1. Запустите игру
2. Проверьте работу всех кнопок
3. Проверьте переходы между меню
4. Проверьте работу слайдеров громкости
5. Проверьте отображение HUD

## Примечания

- Все UI элементы должны быть дочерними объектами Canvas
- Используйте Anchor Points для правильного позиционирования
- Настройте Layer Order для правильного отображения панелей
- Добавьте анимации для плавных переходов
- Используйте EventSystem для обработки ввода 