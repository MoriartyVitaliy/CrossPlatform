Vagrant.configure("2") do |config|

    
    config.vm.define "windows" do |windows|
      windows.vm.box = "gusztavvargadr/windows-10"
      windows.vm.hostname = "windows-vm"
      windows.vm.network "public_network"
      windows.vm.provider "virtualbox" do |vb|
        vb.memory = "4096"
        vb.cpus = 4
      end
      windows.vm.provision "shell", run: "always", inline: <<-SHELL
        # Set execution policy to bypass script restriction
        Set-ExecutionPolicy Bypass -Scope Process -Force

        # Install Chocolatey
        Write-Host "------------------- Installing Chocolatey... -------------------"
        try {
            [System.Net.WebClient]::new().DownloadString('https://chocolatey.org/install.ps1') | Invoke-Expression
        } catch {
            Write-Host "----------------- Failed to install Chocolatey. Exiting... -----------------"
            exit 1
        }

        # Install .NET 8.0 SDK and Runtime
        Write-Host "----------------- Installing .NET 8.0 SDK and Runtime... -----------------"
        choco install dotnet-8.0-sdk -y
        choco install dotnet-8.0-runtime -y
        if (dotnet --version) {
            Write-Host "----------------- .NET Core 8 successfully installed. -----------------"
        } else {
            Write-Host "------------------- Failed to install .NET Core 8. Exiting... ------------------"
            exit 1
        }

        # Verify .NET SDK and Runtime installation
        dotnet --list-sdks
        dotnet --list-runtimes

        # Install .NET Core 3.1 SDK
        Write-Host "------------------- Installing .NET 3.1 SDK -------------------"
        choco install dotnetcore-sdk -y
        if (dotnet --list-sdks | Select-String "3.1") {
            Write-Host "---------------- .NET Core 3.1 SDK successfully installed. ----------------"
        } else {
            Write-Host "---------------- Failed to install .NET Core 3.1 SDK. Exiting... ----------------"
            exit 1
        }

        # Download and extract BaGet
        Write-Host "------------------- Downloading and setting up BaGet... -------------------"
        if (Test-Path "C:/Users/vagrant/baget") {
            Write-Host "---------------------- BaGet is already installed ----------------------"
        } else {
            Invoke-WebRequest -Uri "https://github.com/loic-sharma/BaGet/releases/download/v0.4.0-preview2/BaGet.zip" -OutFile "C:/tmp/BaGet.zip"
            Expand-Archive -Path "C:/tmp/BaGet.zip" -DestinationPath "C:/Users/vagrant/baget" -Force
            Remove-Item "C:/tmp/BaGet.zip"

            if (Test-Path "C:/Users/vagrant/baget") {
                Write-Host "------------------------ BaGet setup complete. ------------------------"
            } else {
                Write-Host "---------------- Failed to set up BaGet. Exiting... ----------------"
                exit 1
            }
        }

        
      
        # Check if BaGet is running
        $response = Invoke-WebRequest -Uri "http://localhost:5000" -UseBasicParsing
        if ($response.StatusCode -eq 200) {
            Write-Host "------------------------- BaGet is already started --------------------------"
        } else {
          
          # Run BaGet
          Write-Host "------------------------- Running BaGet -------------------------"
          cd "C:/Users/vagrant/baget"
          start dotnet BaGet.dll

          try {
            $response2 = Invoke-WebRequest -Uri "http://localhost:5000" -UseBasicParsing
            if ($response2.StatusCode -eq 200) {
                Write-Host "---------------------- BaGet Started successfully ----------------------"
            } else {
                Write-Host "--------------------- Failed to start BaGet. Exiting... ---------------------"
                exit 1
            }
          } catch {
              Write-Host "----------- Failed to connect to BaGet on http://localhost:5000. Exiting... -----------"
              exit 1
          }
        }

        # Add BaGet source and build Lab4
        cd /vagrant/Lab4
        Write-Host "--------------- Configuring BaGet as a NuGet source... ---------------"
        dotnet nuget add source http://localhost:5000/v3/index.json -n BaGet
        if (dotnet nuget list source | Select-String "BaGet") {
            Write-Host "-------------------- BaGet source added successfully --------------------"
        } else {
            Write-Host "---------------- Failed to add BaGet as a NuGet source. Exiting... ----------------"
            exit 1
        }

        Write-Host "--------------------- Building Lab4 project... ---------------------"
        dotnet build
        if (Test-Path "./bin/Release/Lab4.1.0.1.nupkg") {
            Write-Host "--------------------- Lab4 project built successfully ---------------------"
        } else {
            Write-Host "------------------- Failed to build Lab4 project. Exiting... -------------------"
            exit 1
        }

        # Check if package exists in BaGet
        Write-Host "--------------------- Checking if package already exists in BaGet... ---------------------"
        $packageExists = $false
        try {
            $response = Invoke-WebRequest -Uri "http://localhost:5000/v3/registration/VHriss/1.0.1.json" -UseBasicParsing
            if ($response.StatusCode -eq 200) {
                $packageExists = $true
                Write-Host "--------------------- Package already exists in BaGet. Skipping push... ---------------------"
            }
        } catch {

        }

        # Push the package to BaGet if it doesn't exist
        if (-not $packageExists) {
                Write-Host "-------------------- Package does not exist. Pushing package to BaGet... --------------------"
            dotnet nuget push -s http://localhost:5000/v3/index.json ./bin/Release/Lab4.1.0.1.nupkg --skip-duplicate
            if ($?) {
                Write-Host "------------------- Package pushed to BaGet successfully -------------------"
            } else {
                Write-Host "------------------- Failed to push package to BaGet. Exiting... -------------------"
                exit 1
            }
        }

        # Install the tool
        Write-Host "---------------- Installing tool Lab4 globally... ----------------"
        dotnet tool install --global Lab4 --version 1.0.1
        if (dotnet tool list -g | Select-String "Lab4") {
            Write-Host "------------------ Tool VHriss installed successfully ------------------"
        } else {
            Write-Host "------------------- Failed to install tool VHriss. Exiting... -------------------"
            exit 1
        }

        Write-Host "--------------------- Run 'Lab4' to launch the tool. ---------------------"
      SHELL
    end



    config.vm.define "Lab5" do |linux|
      linux.vm.box = "hashicorp/bionic64"
      linux.vm.hostname = "linux-vm-lab5"
      linux.vm.network "public_network"
      linux.vm.network "forwarded_port", guest: 3000, host: 3000
  
      linux.vm.provider "virtualbox" do |vb|
        vb.memory = "4096"
        vb.cpus = 4
      end
  
      linux.vm.provision "shell", run: "always", inline: <<-SHELL
          echo "------------------- Updating system packages... -------------------"
          sudo apt-get update
          
          echo "------------------- Installing prerequisites... -------------------"
          sudo apt-get install -y wget apt-transport-https unzip
  
          echo "------------------- Checking .NET installation... -------------------"
          if ! command -v dotnet &> /dev/null
          then
              echo ".NET SDK not found. Installing .NET SDK 8.0..."
              wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
              sudo dpkg -i packages-microsoft-prod.deb
              sudo apt-get update
              sudo apt-get install -y dotnet-sdk-8.0
          else
              echo ".NET SDK is already installed."
          fi
  
          echo "------------------- Verifying .NET SDK and Runtime versions... -------------------"
          dotnet --list-sdks
          dotnet --list-runtimes
  
          echo "------------------- Building and running Lab5 project... -------------------"
          cd /vagrant/Lab5
          dotnet build
          dotnet run
      SHELL
    end
    
    
end