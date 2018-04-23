# How to use the FrameNavigationService with the Managed Extensibility Framework (MEF)


<p>The FrameNavigationService allows navigating between Views within a NavigationFrame. This example shows how this service can be used along with the <a href="https://msdn.microsoft.com/en-us/library/dd460648(v=vs.110).aspx">Managed Extensibility Framework (MEF)</a>.</p>
<br>
<p>In this example, we've defined a custom ViewLocator for the FrameNavigationService. This ViewLocator uses MEF and can load views dynamically from the external libraries. The MainWindow contains a NavigationFrame, which shows a MenuPage view at startup. The MenuPage contains tiles, which invoke a command to navigate to child views when clicked. Each child view contains the Back button for backward navigation.</p>

<br/>


