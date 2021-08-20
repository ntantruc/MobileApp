using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BomNuoc
{
    public class CancellationTask
    {
        /*
        public class Example
        {
            CancellationTask testTask = new CancellationTask();

            public async void StartTask()
            {
                using (await testTask.LockAsync())
                {
                    await testTask.CancelAsync();

                    testTask.Run(async task =>
                    {
                        while (true)
                        {
                            if (await task.CancelDelay(5000)) return;
                            System.Diagnostics.Debug.WriteLine("Task Running...");

                            if (task.IsCancellationRequested) return;
                        }
                    });
                }
            }

            public async void StopTask()
            {
                using (await testTask.LockAsync())
                {
                    await testTask.CancelAsync();
                }
            }
        }
        */

        Task CurrentTask = null;
        CancellationTokenSource CurrentTokenSource = null;
        AsyncLock CurrentLock = new AsyncLock();

        public bool IsCancellationRequested => CurrentTokenSource.Token.IsCancellationRequested;
        public bool IsPaused = false;

        public Task<IDisposable> LockAsync()
        {
            return CurrentLock.LockAsync();
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public async Task CancelAsync()
        {
            if (CurrentTokenSource != null)
            {
                CurrentTokenSource.Cancel();
                if (CurrentTask != null)
                {
                    await CurrentTask.ConfigureAwait(true);
                }
            }
        }

        public void Run(Func<CancellationTask, Task> action)
        {
            Resume();
            if (CurrentTokenSource != null)
            {
                throw new InvalidOperationException("既にTaskが実行中です");
            }
            CurrentTokenSource = new CancellationTokenSource();
            CurrentTask = Task.Run(async () => await action(this), CurrentTokenSource.Token)
                .ContinueWith(t =>
            {
                if (CurrentTokenSource != null)
                {
                    CurrentTokenSource.Dispose();
                    CurrentTokenSource = null;
                    CurrentTask = null;
                }
            });
        }

        public async Task<bool> CancelDelay(int milliseconds)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < milliseconds)
            {
                await Task.Delay(1);
                if (IsCancellationRequested) return true;
            }
            return false;
        }

        public async Task<bool> PauseWait()
        {
            while (IsPaused)
            {
                await Task.Delay(1);
                if (IsCancellationRequested) return true;
            }
            return false;
        }
    }
}
