# Proyecto Unity - Principios SOLID (S e I)

Este proyecto implementa un **player controlado por el usuario** en Unity, utilizando un modelo 3D con múltiples animaciones (idle, walk, run, jump, attack, etc).  
El objetivo es demostrar el uso de dos principios SOLID aplicados al código:

- **S → Principio de Responsabilidad Única (Single Responsibility Principle)**
- **I → Principio de Inversión de Dependencias (Dependency Inversion Principle)**

---

## Controles

- **WASD** → Mover al personaje  
- **Shift** → Correr  
- **Espacio** → Saltar  
- **Click Izquierdo** → Atacar  

---

## Estructura del proyecto

Conceptos_Solid/
│
├── Assets/
│ ├── Animations/ # Clips de animaciones del monstruo
│ ├── Prefabs/ # Prefab del personaje principal
│ ├── Scripts/ # Código fuente organizado
│ │ ├── Core/ # Entrada y gestión de acciones
│ │ │ ├── PlayerInput.cs
│ │ │ └── ActionInstaller.cs
│ │ ├── Player/ # Lógica principal del jugador
│ │ │ ├── PlayerLocomotion.cs
│ │ │ ├── PlayerAnimator.cs
│ │ │ ├── PlayerCombat.cs
│ │ │ └── PlayerHealth.cs
│ │
│ └── Scenes/
│ └── MainScene.unity
│
├── ProjectSettings/ # Configuración del proyecto
└── Packages/ # Dependencias de Unity

markdown
Copiar código

---

##  Principios SOLID implementados

### 1. **Principio de Responsabilidad Única (SRP)**
Cada script cumple con **una única responsabilidad**:
- `PlayerLocomotion` → Gestiona movimiento (WASD, correr, saltar).  
- `PlayerAnimator` → Actualiza y sincroniza las animaciones.  
- `PlayerCombat` → Controla ataques y acciones ofensivas.  
- `PlayerHealth` → Maneja puntos de vida, daño y muerte.  
- `PlayerInput` → Recoge la entrada del usuario y la expone al resto del sistema.  

Esto garantiza que si se necesita modificar una funcionalidad (por ejemplo, la forma de moverse), **solo se modifica una clase**, sin romper el resto.

---

### 2. **Principio de Inversión de Dependencias (DIP)**
El sistema depende de **abstracciones** y no de implementaciones concretas.  
Se usan **interfaces** y un **instalador** que conecta los componentes:

- `ICharacterAction` define la abstracción de una acción (como moverse o atacar).  
- `ActionInstaller` conecta las implementaciones concretas (`PlayerLocomotion`, `PlayerCombat`, etc) con la interfaz.  

Ejemplo de interfaz:

```csharp
public interface ICharacterAction
{
    void Perform();
}
Ejemplo de implementación:

csharp
Copiar código
public class PlayerCombat : MonoBehaviour, ICharacterAction
{
    public void Perform()
    {
        // Lógica de ataque del jugador
    }
}
De esta forma:

El resto del código no depende de clases concretas, sino de la interfaz.

Se facilita el testing y la posibilidad de cambiar implementaciones en el futuro sin romper nada.

 Resultado
El código queda modular, claro y mantenible.

Se cumple SRP, separando responsabilidades en diferentes scripts.

Se cumple DIP, desacoplando dependencias mediante interfaces.

 Cómo ejecutar el proyecto
Clonar este repositorio.

Abrir la carpeta Conceptos_Solid con Unity 6.2.

Abrir la escena Player.unity.

Ejecutar con el botón Play en el editor.

