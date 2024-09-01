# Unity Design Pattern Project

## 프로젝트 개요

이 프로젝트는 유니티(Unity)를 사용하여 다양한 소프트웨어 디자인 패턴을 구현한 예제입니다. 각 패턴은 게임 개발에서 자주 사용되는 구조를 바탕으로 구현되었으며, 유지보수성, 확장성, 테스트 용이성을 향상시키는 데 중점을 두고 있습니다.

### 구현된 디자인 패턴

- **MVC (Model-View-Controller)**
- **MVP (Model-View-Presenter)**
- **MVVM (Model-View-ViewModel)**

## MVC (Model-View-Controller)

### 개요

MVC 패턴은 애플리케이션의 구조를 모델, 뷰, 컨트롤러로 분리하여 유지보수성과 확장성을 높이는 구조입니다.

### 구성 요소

- **Model:** 데이터를 관리하고 비즈니스 로직을 처리합니다.
- **View:** UI 요소를 통해 데이터를 시각화합니다.
- **Controller:** 사용자 입력을 처리하고, 모델과 뷰를 연결합니다.

### 코드 예시

- **PlayerController.cs**: 사용자 입력에 따라 플레이어의 점수를 업데이트하고, 그 결과를 뷰에 반영합니다.
- **CookieController.cs**: 쿠키 클릭과 자동 클릭기 구매를 처리합니다.

## MVP (Model-View-Presenter)

### 개요

MVP 패턴은 UI 로직과 프레젠테이션 로직을 분리하여 유지보수성과 테스트 용이성을 높이는 구조입니다.

### 구성 요소

- **Model:** 애플리케이션의 데이터와 상태를 관리합니다.
- **View:** 사용자의 입력을 받아들이고, 결과를 화면에 표시합니다.
- **Presenter:** 뷰와 모델 간의 상호작용을 중재하며, 비즈니스 로직을 처리합니다.

### 코드 예시

- **UserPresenter.cs:** 로그인 로직을 처리하고, 결과를 뷰에 전달합니다.

## MVVM (Model-View-ViewModel)

### 개요

MVVM 패턴은 데이터 바인딩을 통해 모델과 뷰를 연결하여 UI 업데이트를 자동화하는 구조입니다.

### 구성 요소

- **Model:** 애플리케이션의 데이터 구조를 정의합니다.
- **ViewModel:** 모델과 뷰 사이의 데이터 바인딩을 관리합니다.
- **View:** 데이터 바인딩을 통해 UI를 업데이트합니다.

### 코드 예시

- **UserViewModel.cs:** 사용자 데이터의 변경 사항을 뷰에 반영하며, 데이터 바인딩을 처리합니다.

## 사용 방법

1. 프로젝트를 클론하고 Unity에서 열어주세요.
2. 각 패턴별로 구현된 씬을 실행하여, 각 디자인 패턴이 어떻게 적용되었는지 확인할 수 있습니다.
3. 코드와 구조를 통해 각 패턴의 장점을 학습할 수 있습니다.

## 참조

- [MVC 패턴 이해 및 활용](https://mayquartet.com/unity-mvcmodel-view-controller-%ed%8c%a8%ed%84%b4-%ec%9d%b4%ed%95%b4-%eb%b0%8f-%ed%99%9c%ec%9a%a9/)
- [MVP 패턴 이해 및 활용](https://mayquartet.com/unity-mvpmodel-view-presenter-%ed%8c%a8%ed%84%b4-%ec%9d%b4%ed%95%b4-%eb%b0%8f-%ed%99%9c%ec%9a%a9/)
- [MVVM 패턴 이해 및 활용](https://mayquartet.com/unity-mvvmmodel-view-viewmodel-%ed%8c%a8%ed%84%b4-%ec%9d%b4%ed%95%b4-%eb%b0%8f-%ed%99%9c%ec%9a%a9/)
