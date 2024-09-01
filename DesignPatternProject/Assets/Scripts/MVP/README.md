# Unity Design Pattern Project - MVP Example

## 프로젝트 개요

이 프로젝트는 유니티(Unity)를 사용하여 MVP(Model-View-Presenter) 디자인 패턴을 구현한 예제입니다. MVP 패턴은 UI 로직과 프레젠테이션 로직을 분리하여 코드의 유지보수성과 테스트 용이성을 높이는 데 중점을 둡니다.

## 프로젝트 구조

### Model

- **UserModel.cs**: 사용자의 이름과 비밀번호를 관리하는 클래스입니다. 사용자 정보의 초기화를 담당합니다.

### View

- **IUserView.cs**: MVP 패턴의 뷰 인터페이스로, 로그인 성공 및 실패 메시지 표시, 사용자 입력값 획득 등의 기능을 정의합니다.
- **LoginView.cs**: 사용자의 로그인 입력을 처리하고 결과를 화면에 표시하는 유니티 뷰 클래스입니다. `IUserView` 인터페이스를 구현합니다.

### Presenter

- **UserPresenter.cs**: 로그인 버튼 클릭 시 사용자의 입력값을 검증하고, 그 결과를 뷰에 전달하는 프레젠터 클래스입니다. 비즈니스 로직을 처리하며 뷰와 상호작용합니다.

## 사용 방법

1. 프로젝트를 클론하고 Unity에서 열어주세요.
2. 로그인 화면에서 "admin"과 "1234"를 입력하여 로그인 성공 또는 실패 메시지를 확인할 수 있습니다.
3. MVP 패턴이 어떻게 적용되었는지 코드와 구조를 통해 학습할 수 있습니다.

## 참조

- [MVP 패턴 이해 및 활용](https://mayquartet.com/unity-mvpmodel-view-presenter-%ed%8c%a8%ed%84%b4-%ec%9d%b4%ed%95%b4-%eb%b0%8f-%ed%99%9c%ec%9a%a9/): 이 프로젝트에서 구현된 MVP 패턴에 대한 추가적인 설명은 이 블로그 글을 참조하세요.
