# Чек-лист настройки UI

## 1. Подготовка сцены
- [ ] Создать новую сцену (File -> New Scene)
- [ ] Сохранить сцену как "MainScene" в папке Scenes
- [ ] Добавить Event System (GameObject -> UI -> Event System)

## 2. Настройка Canvas
- [ ] Создать Canvas (GameObject -> UI -> Canvas)
- [ ] Переименовать в "MainCanvas"
- [ ] Настроить параметры Canvas:
  - [ ] Render Mode: Screen Space - Overlay
  - [ ] UI Scale Mode: Scale With Screen Size
  - [ ] Reference Resolution: 1920 x 1080
  - [ ] Screen Match Mode: Match Width Or Height
  - [ ] Match: 0.5

## 3. Создание структуры UI
- [ ] Создать MainMenuPanel
  - [ ] Добавить Background (Image)
  - [ ] Добавить Title (TextMeshPro)
  - [ ] Создать группу Buttons
    - [ ] Добавить PlayButton (Button)
    - [ ] Добавить SettingsButton (Button)
    - [ ] Добавить ExitButton (Button)

- [ ] Создать SettingsPanel
  - [ ] Добавить Background (Image)
  - [ ] Добавить Title (TextMeshPro)
  - [ ] Создать группу MusicVolume
    - [ ] Добавить Label (TextMeshPro)
    - [ ] Добавить Slider
  - [ ] Создать группу SoundVolume
    - [ ] Добавить Label (TextMeshPro)
    - [ ] Добавить Slider
  - [ ] Добавить BackButton (Button)

- [ ] Создать GameHUDPanel
  - [ ] Создать TopBar
    - [ ] Создать TimeInfo
      - [ ] Добавить DayText (TextMeshPro)
      - [ ] Добавить TimeText (TextMeshPro)
    - [ ] Создать Resources
      - [ ] Добавить WoodText (TextMeshPro)
      - [ ] Добавить StoneText (TextMeshPro)
  - [ ] Добавить MenuButton (Button)

## 4. Настройка компонентов
- [ ] Добавить UIManager на пустой объект
- [ ] Добавить скрипты на панели:
  - [ ] MainMenuPanel.cs
  - [ ] SettingsPanel.cs
  - [ ] GameHUDPanel.cs
- [ ] Настроить ссылки в инспекторе

## 5. Настройка визуальных элементов
- [ ] Настроить кнопки:
  - [ ] Нормальный цвет: белый
  - [ ] При наведении: светло-серый
  - [ ] При нажатии: серый
- [ ] Настроить тексты:
  - [ ] Шрифт: Arial
  - [ ] Размер: 24-36 для обычного текста
  - [ ] Размер: 48-72 для заголовков
- [ ] Настроить слайдеры:
  - [ ] Диапазон: 0-1
  - [ ] Начальное значение: 1

## 6. Настройка анимаций
- [ ] Добавить CanvasGroup на каждую панель
- [ ] Проверить, что неактивные панели скрыты
- [ ] Протестировать переходы между панелями

## 7. Тестирование
- [ ] Проверить работу всех кнопок
- [ ] Проверить сохранение настроек
- [ ] Проверить отображение ресурсов
- [ ] Проверить отображение времени
- [ ] Проверить адаптивность UI при разных разрешениях 